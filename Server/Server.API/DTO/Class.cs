using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.DTO
{
    public class Bookshelf
    {
        public int Limit { get; } = 100;
        public IEnumerable<Book> Books { get; private set; }
        public IEnumerable<Notebook> Notebooks { get; private set; }
        public IEnumerable<Magazine> Magazines { get; private set; }

        public int GetQuantityOfItemsStored()
        {
            return Books.Count() + Notebooks.Count() + Magazines.Count();
        }

        public int GetRemainingSpace()
        {
            return this.Limit - GetQuantityOfItemsStored();
        }

        public void AddNewItem<T>(T item)
        {
            if (GetRemainingSpace() == 0)
                throw new ArgumentOutOfRangeException(nameof(AddNewItem), $"Bookshelf out of space.");

            var type = typeof(T);

            if (type == typeof(Book))
            {
                this.Books = this.Books.Append(item as Book);
            }
            else if (type == typeof(Magazine))
            {
                this.Magazines = this.Magazines.Append(item as Magazine);
            }
            else if (type == typeof(Notebook))
            {
                this.Notebooks = this.Notebooks.Append(item as Notebook);
            }
        }

        public IEnumerable<T> GetByContent<T>(string content)
        {
            var type = typeof(T);

            if (type == typeof(Book))
            {
                return (IEnumerable<T>)this.Books.Where(page => page.hasPageWithContent(content));
            }
            else if (type == typeof(Magazine))
            {
                return (IEnumerable<T>)this.Magazines.Where(page => page.hasPageWithContent(content));
            }
            else if (type == typeof(Notebook))
            {
                return (IEnumerable<T>)this.Notebooks.Where(page => page.hasPageWithContent(content));
            }

            return new List<T>();

        }
    }

    public abstract class GenericBook
    {
        public string Name { get; private set; }
        public int QuantityPages { get; private set; }
        public IEnumerable<Page> Pages { get; private set; }

        public string GetName()
        {
            return this.Name;
        }

        public int GetQuantityPages()
        {
            return this.QuantityPages;
        }

        public Page GetPageByNumber(int pageNumber)
        {
            if (pageNumber > this.QuantityPages)
                throw new ArgumentNullException(nameof(pageNumber),
                    $"This page do not exists. It has only page ={this.QuantityPages}");

            var page = this.Pages.FirstOrDefault(x => x.PageNumber.Equals(pageNumber));
            if (page is null) throw new ArgumentNullException(nameof(pageNumber), "This page do not exists.");
            return page;
        }

        public bool hasPageWithContent(string content)
        {
            var page = this.Pages.Any(pag => pag.Content.Contains("content"));
            return page;
        }
    }

    public class Page
    {
        public string Content { get; private set; }
        public int PageNumber { get; private set; }

        public Page(string content, int pageNumber)
        {
            Content = content;
            PageNumber = pageNumber;
        }
    }

    public class Notebook : GenericBook
    {
        public string Owner { get; private set; }

        public Notebook(string owner)
        {
            Owner = owner;
        }

        public string GetOwner()
        {
            return this.Owner;
        }
    }

    public class Magazine : GenericBook
    {
        public DateTime PublicationDate { get; private set; }

        public DateTime GetPublicationDate()
        {
            return this.PublicationDate;
        }
    }

    public class Book : GenericBook
    {
        public string Author { get; private set; }

        public string GetAuthor()
        {
            return this.Author;
        }
    }
}