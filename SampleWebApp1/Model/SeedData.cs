using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SampleWebApp1.Data;

namespace SampleWebApp1.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SampleContext(serviceProvider.GetRequiredService<DbContextOptions<SampleContext>>()))
            {

                if (context.Patients.Any())
                {
                    return;
                }

                context.Patients.AddRange(
                    new Patient
                    {
                        FirstName = "Jonas",
                        LastName = "Bico",
                        BirthDate = new DateTime(1987, 05, 15),
                    },
                    new Patient
                    {
                        FirstName = "Marvyn",
                        LastName = "Chan",
                        BirthDate = new DateTime(1987, 02, 05)

                    },
                    new Patient
                    {
                        FirstName = "Charles",
                        LastName = "Ong",
                        BirthDate = new DateTime(1985, 12, 5),
                    }
                  );
                context.SaveChanges();

                context.Admissions.AddRange(
                    new Admission
                    {
                        PatientId = 1,
                        AdmissionDate = new DateTime(2018, 09, 09)
                    },
                    new Admission
                    {
                        PatientId = 1,
                        AdmissionDate = new DateTime(2018, 09, 10)
                    },
                    new Admission
                    {
                        PatientId = 1,
                        AdmissionDate = new DateTime(2018, 09, 11)
                    },
                    new Admission
                    {
                        PatientId = 2,
                        AdmissionDate = new DateTime(2018, 09, 01)
                    },
                    new Admission
                    {
                        PatientId = 2,
                        AdmissionDate = new DateTime(2018, 09, 02)
                    },
                    new Admission
                    {
                        PatientId = 2,
                        AdmissionDate = new DateTime(2018, 09, 03)
                    },
                    new Admission
                    {
                        PatientId = 3,
                        AdmissionDate = new DateTime(2018, 08, 01)
                    }
                    );

                context.SaveChanges();


            } 
            
        }
    }
}
