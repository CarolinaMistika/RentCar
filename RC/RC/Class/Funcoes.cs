using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;

namespace RC.Class
{
    public class Funcoes
    {
        public static System.Web.Mvc.JsonResult RetornaJsonResult(string urlHelperAction)
        {
            return new System.Web.Mvc.JsonResult
            {
                Data = new
                {
                    Error = "NotAuthorized",
                    UrlAction = urlHelperAction
                },
                JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet
            };
        }

        public static bool TrataPesquisaInt(string pesquisa)
        {
            try
            {
                if (pesquisa.Trim() == "")
                    return false;
                //Verifica se existe algum caracter especial.
                else if (!(pesquisa.All(c => char.IsLetter(c) || char.IsDigit(c))))
                    return true;
                //Verifica se tem mais de 9 caracteres
                else if (pesquisa.Length > 9)
                    return true;
                //Verifica se  existe pelo menos um caracter minúsculo  ou maiúscula
                if (pesquisa.Any(c => char.IsLower(c) || char.IsUpper(c)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool TrataPesquisaString(string pesquisa)
        {
            try
            {
                if (pesquisa.Trim() == "")
                    return false;
                //Verifica se existe algum caracter aspas simples.
                else if ((pesquisa.Contains('\'')))
                    return true;
                //Verifica se existe alguma letras.
                else if (pesquisa.Where(c => char.IsLower(c)).Count() > 0)
                    return false;
                //Verifica se existe alguma letras.
                else if (pesquisa.Where(c => char.IsUpper(c)).Count() > 0)
                    return false;
                //Verifica se existe alguma caracteres especiais  e não tem %
                else if (pesquisa.Count(p => !char.IsLetterOrDigit(p)) > 0 && !pesquisa.Contains('%'))
                    return false;
                //Verifica se existe algum numero
                else if ((pesquisa.Where(c => char.IsNumber(c)).Count() > 0))
                    return false;
                //Verifica se existe algum caracter %
                else if (pesquisa.Contains('%'))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string EncryptMd5(string input)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

                byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(input));

                System.Text.StringBuilder sbString = new System.Text.StringBuilder();

                for (int i = 0; i < data.Length; i++)
                    sbString.Append(data[i].ToString("x2"));

                return sbString.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            //text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);
            text = text.Replace("\r", "");
            text = text.Replace("\n", "");
            text = text.Replace("\t", "");
            return text;
        }

        public static string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }

        public static string base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }

        public static int FormatarInteiro(string Valor)
        {
            int Diasr = 0;
            if ((Valor == null) || (Valor == ""))
            {
                Diasr = 0;
                return Diasr;
            }
            else
                return Convert.ToInt32(Valor);

        }

        public static string DesembaralhaTexto(string strInicial)
        {
            string strFinal = string.Empty;
            int tamanho = strInicial.Length;

            for (int i = 0; i < tamanho; i += 3)
            {
                switch (strInicial.Substring(i, 3).ToLower())
                {
                    case ":z:":
                        strFinal += "0";
                        break;
                    case ":y:":
                        strFinal += "1";
                        break;
                    case ":x:":
                        strFinal += "2";
                        break;
                    case ":v:":
                        strFinal += "3";
                        break;
                    case ":u:":
                        strFinal += "4";
                        break;
                    case ":t:":
                        strFinal += "5";
                        break;
                    case ":s:":
                        strFinal += "6";
                        break;
                    case ":r:":
                        strFinal += "7";
                        break;
                    case ":q:":
                        strFinal += "8";
                        break;
                    case ":p:":
                        strFinal += "9";
                        break;
                    case ":1:":
                        strFinal += "a";
                        break;
                    case ":2:":
                        strFinal += "e";
                        break;
                    case ":3:":
                        strFinal += "i";
                        break;
                    case ":4:":
                        strFinal += "o";
                        break;
                    case ":5:":
                        strFinal += "u";
                        break;
                    default:
                        strFinal += strInicial.Substring(i, 3).Replace("!", "");
                        break;
                }
            }

            return strFinal;
        }

        public static string GerarSenha()
        {
            Random random = new Random();

            string carac = "abcdefhijkmnopqrstuvxwyz123456789";

            char[] caracter = carac.ToCharArray();

            embaralhar(ref caracter, 3);

            string novaSenha = "";
            for (int i = 0; i < 8; i++)
                novaSenha += caracter[i];

            return novaSenha;
        }

        public static void embaralhar(ref char[] array, int qtd)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < qtd; i++)
            {
                for (int j = 0; j <= array.Length; j++)
                {
                    swap(ref array[random.Next(0, array.Length)],
                         ref array[random.Next(0, array.Length)]);
                }
            }
        }

        public static void swap(ref char arg1, ref char arg2)
        {
            char temp = arg1;
            arg1 = arg2;
            arg2 = temp;
        }

        public static string Formatardata(string data)
        {
            if (data == null || data == string.Empty)
            {
                return null;
            }
            else
                return Convert.ToDateTime(data).ToString("yyyy-MM-dd");
        }

        public static string Formatardata2(string data)
        {
            if (data == null || data == string.Empty)
            {
                return null;
            }
            else
                return Convert.ToDateTime(data).ToString("yyyy-MM-dd H:mm:ss");
        }

        public static string FormataStringVazia(string Valor)
        {
            if (Valor == null)
            {
                return string.Empty;
            }
            else return Valor;

        }

        public static byte[] base64DecodeByte(string stringEncoded)
        {
            try
            {
                byte[] dadosBytes = System.Convert.FromBase64String(stringEncoded);
                return dadosBytes;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }

        public static void EMail(string sub, string body, string destinatario)
        {
            try
            {
                string cabecalho = "<table class='trello-block trello-block-background--trello-blue' style='background-color: #0079BF; border-collapse: collapse;" +
                    " border-spacing: 0; color: #fff; padding: 0; text-align: inherit; vertical-align: top; width: 100%'>" +
                    "<tbody><tr style='padding: 0; text-align: left; vertical-align: top'>" +
                    "<td style='-moz-hyphens: auto; -webkit-hyphens: auto; border-collapse: collapse; color: #4d4d4d; font-family: 'Helvetica', 'Arial'," +
                    " sans-serif; font-size: 14px; font-weight: normal; hyphens: auto; line-height: 19px; margin: 0; padding: 0; text-align: left; vertical-align:" +
                    " top; word-break: break-word'><div class='trello-block-single-column center' style='display: block; margin: 0 auto; max-width: 580px; padding: 12px 16px'>" +
                    "<h2 style='text-align: center;'>ESTE É UM E-MAIL PADRÃO DO RENTAL CAR!</h2><br/>" +
                    "</div></td> </tr></tbody></table>";
                string msg = cabecalho;
                string remetenteEmail = ConfigurationManager.AppSettings["Email"];
                string senha = ConfigurationManager.AppSettings["Senha"];
                MailMessage mail = new MailMessage();
                mail.To.Add(destinatario);
                mail.From = new MailAddress(remetenteEmail, "RENTAL CAR", System.Text.Encoding.UTF8);
                mail.Subject = sub;
                mail.Body = EstruturaHtmlEmail(msg + "<h3>" + body + "</h3>");
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(remetenteEmail, senha);
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                try { client.Send(mail); }
                catch (Exception ex) { }

            }
            catch (Exception ex)
            {
            }

        }

        public static string EstruturaHtmlEmail(string texto)
        {
            string retorno = "<hr/><p>" + texto + "</p><hr />";
            return retorno;

        }

        public static bool validaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool validaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}