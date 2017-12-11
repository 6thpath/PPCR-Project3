using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCR.Models;
using PPCR.AcceptanceTest;
using PPCR.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Web.Mvc;

namespace PPCR.AcceptanceTest.Drivers
{
    class ProjectDetailsDriver
    {
        //private readonly PROPERTY _Property;
        //private readonly CatalogContext _context;   
        //private ActionResult _result;

        //public ProjectDetailsDriver(PROPERTY context)
        //{
        //    _Property = context;
        //}

        //public void InsertPropertyToDB(Table Properties)
        //{
        //    using (var db = new PROPERTY())
        //    {
        //        foreach (var row in Properties.Rows)
        //        {
        //            var Property = new PROPERTY
        //            {
        //                Author = row["Author"],
        //                Title = row["Title"],
        //                Price = Books.Header.Contains("Price")
        //                    ? Convert.ToDecimal(row["Price"])
        //                    : BookDefaultPrice
        //            };

        //            _context.ReferenceBooks.Add(
        //                    Books.Header.Contains("Id") ? row["Id"] : book.Title,
        //                    book);

        //            db.Books.Add(book);
        //        }

        //        db.SaveChanges();
        //    }
        //}

        //public void ShowBookDetails(Table shownBookDetails)
        //{
        //    //Arrange
        //    var expectedBookDetails = shownBookDetails.Rows.Single();

        //    //Act
        //    var actualBookDetails = _result.Model<Book>();

        //    //Assert
        //    actualBookDetails.Should().Match<Book>(
        //        b => b.Title == expectedBookDetails["Title"]
        //        && b.Author == expectedBookDetails["Author"]
        //        && b.Price == decimal.Parse(expectedBookDetails["Price"]));
        //}

        //public void OpenBookDetails(string bookId)
        //{
        //    var book = _context.ReferenceBooks.GetById(bookId);
        //    using (var controller = new CatalogController())
        //    {
        //        _result = controller.Details(book.Id);
        //    }
        //}
    }
}
