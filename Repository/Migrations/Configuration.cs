namespace Repository.Migrations
{
    using System;
    using System.IO;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repository.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Web.Hosting;
    using System.Reflection;
    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Models.CVHostingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Repository.Models.CVHostingContext context)
        {
            //  This method will be called after migrating to the latest version.

            // Do debugowania metody seed
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            SeedRoles(context);
            SeedUsers(context);
            SeedAvailability(context);
            SeedPlace(context);
            SeedCV(context);
            //SeedFile(context);
        }

        private void SeedRoles(CVHostingContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(CVHostingContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {

                var user = new User { UserName = "admin@localhost.pl", Email = "admin@localhost.pl", Age = 24, Name = "Admin" };

                var adminresult = manager.Create(user, "ZAQ!2wsx");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "Trufel"))
            {
                var user = new User { UserName = "trufel@op.pl", Email = "trufel@op.pl", Age = 24, Name = "Trufel" };

                var adminresult = manager.Create(user, "ZAQ!2wsx");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "User");
            }
            if (!context.Users.Any(u => u.UserName == "Marek"))
            {

                var user = new User { Email = "marek@test.pl", UserName = "Marek@op.pl", Age = 30, Name = "User Test" };
                //var user = new User { UserName = "Admin" };

                var adminresult = manager.Create(user, "ZAQ!2wsx");

            }
        }

        private void SeedAvailability(CVHostingContext context)
        {
            List<string> availabilityNames = new List<string>() { "Do 20h tygodniowo", "20h tygodniowo",
                "21h - 29h tygodniowo", "30h - 39h tygodniowo", "Pe³en etat (40h)" };

            foreach (var name in availabilityNames)
            {
                var a = new Availability() { Name = name };
                context.Set<Availability>().AddOrUpdate(a);
            }

            context.SaveChanges();
        }

        private void SeedPlace(CVHostingContext context)
        {
            List<string> placeNames = new List<string>() { "Z og³oszenia", "Od pracownika HeadChannel", "Z bloga technicznego",
                "Ze strony www", "Z mediów spo³ecznoœciowych", "Z uczelni", "Z wczeœniejszej rekrutacji", "Inne Ÿród³o" };

            foreach (var name in placeNames)
            {
                var a = new Place() { Name = name };
                context.Set<Place>().AddOrUpdate(a);
            }

            context.SaveChanges();
        }

        private void SeedCV(CVHostingContext context)
        {
            SeedFile(context);

            int placeId = context.Set<Place>().First().Id;
            int availabilityId = context.Set<Availability>().First().Id;
            int cvFileId = context.Set<CVFile>().First().Id;
            CVApplication cv = new CVApplication()
            {
                AvailabilityId = availabilityId,
                PlaceId = placeId,
                DataDodania = DateTime.Now,
                Description = "Dodatkowy opis",
                Email = "rafal.chodzidlo92@gmail.com",
                Name = "Rafa³ Chodzid³o",
                Phone = "530529985",
                Workplace = "ASP.NET",
                CVFileId = cvFileId
            };

                context.Set<CVApplication>().AddOrUpdate(cv);

            context.SaveChanges();
        }

        private void SeedFile(CVHostingContext context)
        {
            var fileStream = GetResourceFileStream("Repository.Files", "CV_RAFAL_CHODZIDLO_ENG.pdf");

            byte[] file = ReadToEnd(fileStream);

            CVFile cvFile = new CVFile() { Content = file };

            context.Set<CVFile>().AddOrUpdate(cvFile);
            context.SaveChanges();
        }

        public static Stream GetResourceFileStream(String nameSpace, String filePath)
        {
            String pseduoName = filePath.Replace('\\', '.');
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(nameSpace + "." + pseduoName);
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

    }
}
