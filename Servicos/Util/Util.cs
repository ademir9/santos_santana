using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicos.Util
{
    public static class Util
    {

        public static string RemoveAcentos(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            System.Text.Encoding destEncoding = System.Text.Encoding.GetEncoding("iso-8859-8");

            return destEncoding.GetString(
              System.Text.Encoding.Convert(System.Text.Encoding.UTF8, destEncoding, System.Text.Encoding.UTF8.GetBytes(s)));
        }

        #region Validaçoes

        /// <summary>
        /// Checks if the string is a valid Email.
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Returns true if it is a valid email address</returns>
        public static bool IsValidEmail(this string val)
        {
            if (string.IsNullOrEmpty(val)) return false;

            const string expresion = @"^(?:[a-zA-Z0-9_'^&/+-])+(?:\.(?:[a-zA-Z0-9_'^&/+-])+)*@(?:(?:\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\]?)|(?:[a-zA-Z0-9-]+\.)+(?:[a-zA-Z]){2,}\.?)$";
            Regex regex = new Regex(expresion, RegexOptions.IgnoreCase);
            return regex.IsMatch(val);
        }

        /// <summary>
        /// Valida um CPF
        /// </summary>
        /// <param name="Cpf">Número do CPF (incluindo os digitos)</param>
        /// <returns>True CPF válido ou False CPF inválido</returns>
        public static bool IsValidCPF(this string Cpf)
        {
            try
            {
                Cpf = Cpf.Replace(".", "").Replace("-", "");

                if (Cpf.Contains("0000") || Cpf.Contains("1111") || Cpf.Contains("2222") || Cpf.Contains("3333") || Cpf.Contains("4444") || Cpf.Contains("5555") || Cpf.Contains("6666") || Cpf.Contains("7777") || Cpf.Contains("8888") || Cpf.Contains("9999"))
                    return false;

                int d1, d2;
                int digito1, digito2, resto;
                int digitoCPF;
                string nDigResult;

                if (Cpf.Length != 11 ||
                    Convert.ToInt64(Cpf) == 0)
                    return false;

                d1 = d2 = 0;
                digito1 = digito2 = resto = 0;

                for (int nCount = 1; nCount < Cpf.Length - 1; nCount++)
                {
                    digitoCPF = Convert.ToInt32(Cpf.Substring(nCount - 1, 1));

                    //multiplique a ultima casa por 2 a seguinte por 3 a seguinte por 4 e assim por diante.
                    d1 = d1 + (11 - nCount) * digitoCPF;

                    //para o segundo digito repita o procedimento incluindo o primeiro digito calculado no passo anterior.
                    d2 = d2 + (12 - nCount) * digitoCPF;
                };

                //Primeiro resto da divisão por 11.
                resto = (d1 % 11);

                //Se o resultado for 0 ou 1 o digito é 0 caso contrário o digito é 11 menos o resultado anterior.
                if (resto < 2)
                    digito1 = 0;
                else
                    digito1 = 11 - resto;

                d2 += 2 * digito1;

                //Segundo resto da divisão por 11.
                resto = (d2 % 11);

                //Se o resultado for 0 ou 1 o digito é 0 caso contrário o digito é 11 menos o resultado anterior.
                if (resto < 2)
                    digito2 = 0;
                else
                    digito2 = 11 - resto;

                //Digito verificador do CPF que está sendo validado.
                String nDigVerific = Cpf.Substring(Cpf.Length - 2, 2);

                //Concatenando o primeiro resto com o segundo.
                nDigResult = digito1.ToString() + digito2.ToString();

                //comparar o digito verificador do cpf com o primeiro resto + o segundo resto.
                return nDigVerific.Equals(nDigResult);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida o CNPJ
        /// </summary>
        /// <param name="Cnpj">CNPJ a ser validado</param>
        /// <returns>True CNPJ válido ou False CNPJ inválido</returns>
        public static bool IsValidCNPJ(this string Cnpj)
        {
            Cnpj = Cnpj.Replace(".", "").Replace(@"/", "").Replace("-", "");
            try
            {
                int soma = 0, dig;

                if (Cnpj.Length != 14)
                    return false;

                string cnpj_calc = Cnpj.Substring(0, 12);

                char[] chr_cnpj = Cnpj.ToCharArray();

                /* Primeira parte */
                for (int i = 0; i < 4; i++)
                    if (chr_cnpj[i] - 48 >= 0 && chr_cnpj[i] - 48 <= 9)
                        soma += (chr_cnpj[i] - 48) * (6 - (i + 1));
                for (int i = 0; i < 8; i++)
                    if (chr_cnpj[i + 4] - 48 >= 0 && chr_cnpj[i + 4] - 48 <= 9)
                        soma += (chr_cnpj[i + 4] - 48) * (10 - (i + 1));
                dig = 11 - (soma % 11);

                cnpj_calc += (dig == 10 || dig == 11) ?
                    "0" : dig.ToString();

                /* Segunda parte */
                soma = 0;
                for (int i = 0; i < 5; i++)
                    if (chr_cnpj[i] - 48 >= 0 && chr_cnpj[i] - 48 <= 9)
                        soma += (chr_cnpj[i] - 48) * (7 - (i + 1));
                for (int i = 0; i < 8; i++)
                    if (chr_cnpj[i + 5] - 48 >= 0 && chr_cnpj[i + 5] - 48 <= 9)
                        soma += (chr_cnpj[i + 5] - 48) * (10 - (i + 1));
                dig = 11 - (soma % 11);
                cnpj_calc += (dig == 10 || dig == 11) ?
                    "0" : dig.ToString();

                return Cnpj.Equals(cnpj_calc);
            }
            catch (Exception)
            {
                return false;
            }
        }




        #endregion
    }
}
