using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ClsUtility
    {
        public static string key = ConfigurationManager.AppSettings["EnKey"].ToString();
        public static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            System.Security.Cryptography.TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        public static string Encryption(string PlainText)
        {
            System.Security.Cryptography.TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(PlainText);
            byte[] buffer = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(buffer);
        }
        public static string Decryption(string CypherText)
        {
            byte[] b = Convert.FromBase64String(CypherText);
            System.Security.Cryptography.TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }


        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private static string strReplicate(string str, int intD)
        {
            string functionReturnValue = null;
            //This fucntion padded "0" after the number to evaluate hundred, thousand and on....
            //using this function you can replicate any Charactor with given string.
            int i = 0;
            functionReturnValue = "";
            for (i = 1; i <= intD; i++)
            {
                functionReturnValue = functionReturnValue + str;
            }
            return functionReturnValue;

        }
        public static string AmtInWord(double Num)
        {
            string functionReturnValue = null;
            //I have created this function for converting amount in indian rupees (INR). 
            //You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

            string strNum = null;
            string strNumDec = null;
            string StrWord = null;
            strNum = Num.ToString();

            if (Strings.InStr(1, strNum, ".") != 0)
            {
                strNumDec = Strings.Mid(strNum, Strings.InStr(1, strNum, ".") + 1);

                if (Strings.Len(strNumDec) == 1)
                {
                    strNumDec = strNumDec + "0";
                }
                if (Strings.Len(strNumDec) > 2)
                {
                    strNumDec = Strings.Mid(strNumDec, 1, 2);
                }

                strNum = Strings.Mid(strNum, 1, Strings.InStr(1, strNum, ".") - 1);
                StrWord = NumToWord(Convert.ToDouble(strNum)) + (Convert.ToDouble(strNumDec) > 0 ? " and Paise " + cWord3(Convert.ToDouble(strNumDec)) : "");
            }
            else
            {
                StrWord = NumToWord(Convert.ToDouble(strNum));
            }
            functionReturnValue = StrWord + " Only";
            return functionReturnValue;
        }
        private static string NumToWord(double Num)
        {
            //I divided this function in two part.
            //1. Three or less digit number.
            //2. more than three digit number.
            string strNum = null;
            string StrWord = null;
            strNum = Num.ToString();

            if (Strings.Len(strNum) <= 3)
            {
                StrWord = cWord3(Convert.ToDouble(strNum));
            }
            else
            {
                StrWord = cWordG3(Convert.ToDouble(Strings.Mid(strNum, 1, Strings.Len(strNum) - 3))) + " " + cWord3(Convert.ToDouble(Strings.Mid(strNum, Strings.Len(strNum) - 2)));
            }
            return StrWord;
        }
        private static string cWordG3(double Num)
        {
            string functionReturnValue = null;
            //2. more than three digit number.
            string strNum = "";
            string StrWord = "";
            double readNum = 0;
            strNum = Num.ToString();
            if (Strings.Len(strNum) % 2 != 0)
            {
                readNum = Convert.ToDouble(Strings.Mid(strNum, 1, 1));
                if (readNum != 0)
                {
                    StrWord = retWord(readNum);
                    readNum = Convert.ToDouble("1" + strReplicate("0", Strings.Len(strNum) - 1) + "000");
                    StrWord = StrWord + " " + retWord(readNum);
                }
                strNum = Strings.Mid(strNum, 2);
            }
            while (!(Strings.Len(strNum) == 0))
            {
                readNum = Convert.ToDouble(Strings.Mid(strNum, 1, 2));
                if (readNum != 0)
                {
                    StrWord = StrWord + " " + cWord3(readNum);
                    readNum = Convert.ToDouble("1" + strReplicate("0", Strings.Len(strNum) - 2) + "000");
                    StrWord = StrWord + " " + retWord(readNum);
                }
                strNum = Strings.Mid(strNum, 3);
            }
            functionReturnValue = StrWord;
            return functionReturnValue;

        }
        private static string cWord3(double Num)
        {
            string functionReturnValue = null;
            //1. Three or less digit number.
            string strNum = "";
            string StrWord = "";
            double readNum = 0;
            if (Num < 0)
                Num = Num * -1;
            strNum = Num.ToString();

            if (Strings.Len(strNum) == 3)
            {
                readNum = Convert.ToDouble(Strings.Mid(strNum, 1, 1));
                StrWord = retWord(readNum) + " Hundred";
                strNum = Strings.Mid(strNum, 2, Strings.Len(strNum));
            }

            if (Strings.Len(strNum) <= 2)
            {
                if (Convert.ToDouble(strNum) >= 0 & Convert.ToDouble(strNum) <= 20)
                {
                    StrWord = StrWord + " " + retWord(Convert.ToDouble(strNum));
                }
                else
                {
                    StrWord = StrWord + " " + retWord(Convert.ToDouble(Strings.Mid(strNum, 1, 1) + "0")) + " " + retWord(Convert.ToDouble(Strings.Mid(strNum, 2, 1)));
                }
            }

            strNum = Convert.ToString(Num);
            functionReturnValue = StrWord;
            return functionReturnValue;
        }
        private static string retWord(double Num)
        {
            string functionReturnValue = null;
            //This two dimensional array store the primary word convertion of number.
            functionReturnValue = "";
            object[,] ArrWordList = {
                {
                    0,
                    ""
                },
                {
                    1,
                    "One"
                },
                {
                    2,
                    "Two"
                },
                {
                    3,
                    "Three"
                },
                {
                    4,
                    "Four"
                },
                {
                    5,
                    "Five"
                },
                {
                    6,
                    "Six"
                },
                {
                    7,
                    "Seven"
                },
                {
                    8,
                    "Eight"
                },
                {
                    9,
                    "Nine"
                },
                {
                    10,
                    "Ten"
                },
                {
                    11,
                    "Eleven"
                },
                {
                    12,
                    "Twelve"
                },
                {
                    13,
                    "Thirteen"
                },
                {
                    14,
                    "Fourteen"
                },
                {
                    15,
                    "Fifteen"
                },
                {
                    16,
                    "Sixteen"
                },
                {
                    17,
                    "Seventeen"
                },
                {
                    18,
                    "Eighteen"
                },
                {
                    19,
                    "Nineteen"
                },
                {
                    20,
                    "Twenty"
                },
                {
                    30,
                    "Thirty"
                },
                {
                    40,
                    "Forty"
                },
                {
                    50,
                    "Fifty"
                },
                {
                    60,
                    "Sixty"
                },
                {
                    70,
                    "Seventy"
                },
                {
                    80,
                    "Eighty"
                },
                {
                    90,
                    "Ninety"
                },
                {
                    100,
                    "Hundred"
                },
                {
                    1000,
                    "Thousand"
                },
                {
                    100000,
                    "Lakh"
                },
                {
                    10000000,
                    "Crore"
                }
            };

            int i = 0;
            for (i = 0; i <= Information.UBound(ArrWordList); i++)
            {
                if (Num == Convert.ToDouble(ArrWordList[i, 0].ToString()))
                {
                    functionReturnValue = ArrWordList[i, 1].ToString();
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return functionReturnValue;
        }

        public static bool SendEmail(string toemail, string subject, string body, string cc = "", string bcc = "")
        {

            string senderID = ConfigurationManager.AppSettings["senderID"].ToString();
            string senderPassword = ConfigurationManager.AppSettings["senderPassword"].ToString();
            string HostServer = ConfigurationManager.AppSettings["Host"].ToString();
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = HostServer, // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };

                MailMessage message = new MailMessage(senderID, toemail, subject, body);
                message.IsBodyHtml = true;
                if (cc != "")
                {
                    message.CC.Add(cc);
                }

                if (bcc != "")
                {
                    message.Bcc.Add(bcc);
                }

                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool SendEmailAttachment(string toemail, string subject, string body, string filename, string cc = "", string bcc = "")
        {

            string senderID = ConfigurationManager.AppSettings["senderID"].ToString();
            string senderPassword = ConfigurationManager.AppSettings["senderPassword"].ToString();
            string HostServer = ConfigurationManager.AppSettings["Host"].ToString();
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = HostServer, // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };

                MailMessage message = new MailMessage(senderID, toemail, subject, body);
                message.IsBodyHtml = true;
                if (cc != "")
                {
                    message.CC.Add(cc);
                }

                if (bcc != "")
                {
                    message.Bcc.Add(bcc);
                }

                Attachment attachment = new Attachment(filename);
                message.Attachments.Add(attachment);

                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
