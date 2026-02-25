using System.Linq;
using IndyBooks.Models;
using IndyBooks.ViewModels;

namespace IndyBooks.Services;

public class Repository
{
    private IndyBooksDataContext _db;

    public Repository(IndyBooksDataContext db)
    {
        _db = db;
    }   
    //Property to return ALL Books on sale (price greater than 90) with the price reduced by 50%
    public decimal sale{ get; set; } = 0.5m; //percentage off for the sale
    public int SaleLimit { get;set; } = 90; // the item price above this amount will be on sale
    //TODO: complete the SaleResults property to show reduced-priced books (done)
    public IEnumerable<Book> SaleResults {
        get {
            return _db.Books
                .Where(b => b.Price > SaleLimit)
                .Select(b => new Book {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Price = b.Price * (1 - sale) // apply the discount
                });
                
        }
    }
    
    //TODO: complete method to return search results based on the given SearchVM criteria (done)
    public IEnumerable<Book> searchResults(SearchVM searchVM) {
            IQueryable<Book> foundBooks = _db.Books; // start with entire collection

            //Filter the collection using the non-empty Title Field as noted
            if (searchVM.Title != null && searchVM.Title.Trim().Length > 0)
            {
                //Filter the collection by Title which "contains" the given string
                foundBooks = foundBooks
                             .Where(b => b.Title.Contains(searchVM.Title))
                // TODO: Order the results by Title (Done)
                             .OrderBy(b => b.Title);
            }

            //TODO: Add similar logic to filter foundbooks collection by last part of the Author's Name, if given
            // (HINT: consider the EndsWith() method, also adjust the Search View and ViewModel to add items) (Done)
            if (searchVM.AuthorsLastName != null && searchVM.AuthorsLastName.Trim().Length > 0)
            {
                foundBooks = foundBooks
                             .Where(b => b.Author.EndsWith(searchVM.AuthorsLastName))
                             .OrderBy(b => b.Author);
            }

            //TODO: Add similar logic to filter foundbooks collection by price, if given (done)
            //       order the results by descending price 
            // (Note: you will need to adjust the Search ViewModel and View to add search fields)
            if (searchVM.MinimumPrice != null)
            {
                foundBooks = foundBooks
                             .Where(b => b.Price >= searchVM.MinimumPrice)
                             .OrderBy(b => (float)b.Price);
            }
            if (searchVM.MaximumPrice != null)
            {
                foundBooks = foundBooks
                             .Where(b => b.Price <= searchVM.MaximumPrice)
                             .OrderByDescending(b => (float)b.Price);
            }


            return foundBooks.ToList();
    }   

};     


