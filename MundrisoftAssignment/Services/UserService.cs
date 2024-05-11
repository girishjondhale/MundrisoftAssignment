using MundrisoftAssignment.Models;
using MundrisoftAssignment.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace MundrisoftAssignment.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public Users Authenticate(Users user)
        {
            Users u = _repo.Authenticate(user);
            if (u != null)
            {
                string decryptpass = Decrypt(u.Password);
                u.Password = decryptpass;
                if (u.Password == user.Password)
                {
                    return u;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public int RegisterUser(Users user)
        {
            string encryptpass = Encrypt(user.Password);
            user.Password = encryptpass;
            return _repo.RegisterUser(user);
        }

        public int UpdatePassword(Users users)
        {
            string encryptpass = Encrypt(users.Password);
            users.Password = encryptpass;
            return _repo.UpdatePassword(users);
        }
        public string Encrypt(string pass)
        {
            try
            {
                string textToEncrypt = pass;
                string ToReturn = "";
                string publickey = "abcdefgh";
                string secretkey = "hgfedcba";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Decrypt(string pass)
        {
            try
            {
                string textToDecrypt = pass;
                string ToReturn = "";
                string publickey = "abcdefgh";
                string privatekey = "hgfedcba";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
