using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Bu kod verdiğimiz bir password değerinin hash ve salt değerini oluşturur.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //her kullanıcı için ayrı bir key oluşturulur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //byte 
            }
        }

        //Bu kullanıcının passwordunu yine aynı algoritmayı kullanarak hashleseydin karşına böyle bir şey çıkar mıydı (iki hash değerinin karşılaştırıyoruz yani)
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //tekrar hashledik ki karşılaştırabilelim.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
