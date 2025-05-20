using System;
using System.Security.Cryptography;
using System.Text;

namespace lib_dominio.Nucleo
{
    public static class EncriptarConversor
    {
        public static Aes Crear()
        {
            Aes aes = Aes.Create();

            try
            {
                
                byte[] keyBytes = Encoding.UTF8.GetBytes(DatosGenerales.clave);
                byte[] validKey = new byte[32]; 

                
                Array.Copy(keyBytes, validKey, Math.Min(keyBytes.Length, validKey.Length));

                aes.Key = validKey;

                
                if (string.IsNullOrEmpty(DatosGenerales.usuario_datos))
                {
                    aes.GenerateIV();
                }
                else
                {
                    byte[] ivBytes = Encoding.UTF8.GetBytes(DatosGenerales.usuario_datos);
                    byte[] validIV = new byte[16]; 
                    Array.Copy(ivBytes, validIV, Math.Min(ivBytes.Length, validIV.Length));
                    aes.IV = validIV;
                }
            }
            catch (Exception)
            {
               
                aes.GenerateKey();
                aes.GenerateIV();

                
                DatosGenerales.clave = Convert.ToBase64String(aes.Key);
                DatosGenerales.usuario_datos = Convert.ToBase64String(aes.IV);
            }

            return aes;
        }

        public static string Encriptar(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                return string.Empty;

            using (Aes aes = Crear())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(textoPlano);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Desencriptar(string textoCifrado)
        {
            if (string.IsNullOrEmpty(textoCifrado))
                return string.Empty;

            try
            {
                using (Aes aes = Crear())
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(textoCifrado)))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
