﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.SERVICE.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
