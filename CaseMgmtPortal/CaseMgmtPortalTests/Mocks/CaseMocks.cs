using CaseMgmtPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseMgmtPortalTests.Mocks
{
    public class CaseMocks
    {
        public static Case GetCase()
        {
            var childCase = new Case()
            {
                Id = 1,

                Child = new Child
                {
                    Id = 1,
                    FirstName = "John",
                    MiddleName = "Doe",
                    LastName = "Cena",
                    StreetAddress = "1234 GeryLane Ave",
                    City = "Baton Rouge",
                    State = "Louisiana",
                    ZipCode = "70817",
                    Details = "Here's some details.",
                    IsDeleted = false
                },

                ChildId = 1,

                Reporter = new Reporter()
                {
                    Id = 1,
                    FirstName = "Leia",
                    MiddleName = "Doe",
                    LastName = "Amadalla",
                    Email = "Leia@planet.com",
                    Phone = "5558675309",
                    IsDeleted = false
                },

                ReporterId = 1,

                IsDeleted = false,

                Date = DateTime.Now,

                UpdateDate = DateTime.Now,

                Status = "Some status.",

                Notes = "Some notes."
            };

            return childCase;
        }

        //public static Case GetInvalidCase()
        //{
        //    var childCase = new Case()
        //    {
        //        Id = 1,

        //        Child = new Child
        //        {
        //            //Id = 1,
        //            //FirstName = "John",
        //            //MiddleName = "Doe",
        //            //LastName = "Cena",
        //            //StreetAddress = "1234 GeryLane Ave",
        //            //City = "Baton Rouge",
        //            //State = "Louisiana",
        //            //ZipCode = "70817",
        //            //Details = "Here's some details.",
        //            //IsDeleted = false
        //        },

        //        ChildId = 1,

        //        Reporter = new Reporter()
        //        {
        //            Id = 1,
        //            FirstName = "Leia",
        //            MiddleName = "Doe",
        //            LastName = "Amadalla",
        //            Email = "Leia@planet.com",
        //            Phone = "5558675309",
        //            IsDeleted = false
        //        },

        //        ReporterId = 1,

        //        IsDeleted = false,

        //        Date = DateTime.Now,

        //        UpdateDate = DateTime.Now,

        //        Status = "Some status.",

        //        Notes = "Some notes."
        //    };

        //    return childCase;
        //}
    }
}
