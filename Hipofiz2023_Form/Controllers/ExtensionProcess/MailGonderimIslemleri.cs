using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MimeKit;
using Model;
using VeritabaniIslemMerkezi;
using System.Text;
using MailKit;
using MailKit.Net.Smtp;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Net.Http;

namespace VeritabaniIslemMerkezi
{
    public class MailGonderimIslemleri
    {

        StringBuilder HtmlContent = new StringBuilder();

        public void MailGonder(KatilimciTablosuModel KModel)
        {
            using (MimeMessage mm = new MimeMessage())
            {
                mm.From.Add(new MailboxAddress("Hipofiz 2023", "test@arkadyas.com"));
                mm.To.Add(new MailboxAddress("Kadir Çağlar", "kadircaglar@consensustourism.com"));
                mm.Subject = "Hipofiz 2023 Kayıt Bilgilendirme";

                mm.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = KModel.HtmlContent
                };

                using (ProtocolLogger logger = new ProtocolLogger(HttpContext.Current.Server.MapPath($"~/Dosyalar/MailLog/{KModel.ePosta}_{DateTime.Now:yyyy.MM.dd HH.mm.ss}.log")))
                {
                    using (SmtpClient client = new SmtpClient(logger))
                    {
                        try
                        {
                            client.Connect("mail.arkadyas.com", 587, MailKit.Security.SecureSocketOptions.None);
                            client.Authenticate("test@arkadyas.com", "wesSv3A!");
                            client.Send(mm);

                            if (client.IsConnected)
                            {
                                client.Disconnect(true);
                            }
                        }
                        catch (Exception ex)
                        {
                            byte[] ExecptionBytes = Encoding.UTF8.GetBytes($"{ex.Message}\r\n");
                            logger.Stream.Write(ExecptionBytes, 0, ExecptionBytes.Length);
                            if (client.IsConnected)
                            {
                                client.Disconnect(false);
                            }
                        }
                        
                    }
                }
            }
        }
    }
}