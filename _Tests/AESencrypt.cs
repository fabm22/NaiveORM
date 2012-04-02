using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveORM.Tests
{
    class AESencrypt
    {
        static const string _InitialVector="OFRna73m*aze01xY"; //wtf?

        public static string Encrypt(string PlainText, string Password, string Salt = "Whatever",
                string HashAlgorithm = "SHA1", int PasswordIterations = 2, string InitialVector = _InitialVector,
                int KeySize = 256)
        {
            if(string.IsNullOrEmpty(PlainText)
                return "";

            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValuesBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);

        //    PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);

            return "";
        }
    }
}
