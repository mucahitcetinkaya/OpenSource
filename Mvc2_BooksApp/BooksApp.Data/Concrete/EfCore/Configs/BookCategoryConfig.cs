using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Configs
{
    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.HasData(
                new BookCategory { BookId=1, CategoryId=5},
                new BookCategory { BookId=1, CategoryId=10},

                new BookCategory { BookId=2, CategoryId=13},
                new BookCategory { BookId=2, CategoryId=4},

                new BookCategory { BookId=3, CategoryId=5},
                new BookCategory { BookId=3, CategoryId=1},
                new BookCategory { BookId=3, CategoryId=10},

                new BookCategory { BookId = 4, CategoryId = 5 },
                new BookCategory { BookId = 4, CategoryId = 1 },
                new BookCategory { BookId = 4, CategoryId = 10 },

                new BookCategory { BookId=5, CategoryId=5},
                new BookCategory { BookId=5, CategoryId=10},
                new BookCategory { BookId=5, CategoryId=3},

                new BookCategory { BookId = 6, CategoryId = 5 },
                new BookCategory { BookId = 6, CategoryId = 10 },
                new BookCategory { BookId = 6, CategoryId = 3 },

                new BookCategory { BookId=7, CategoryId=5},
                new BookCategory { BookId=7, CategoryId=1},

                new BookCategory { BookId = 8, CategoryId = 5 },
                new BookCategory { BookId = 8, CategoryId = 10 },
                new BookCategory { BookId = 8, CategoryId = 3 },

                new BookCategory { BookId=9, CategoryId=7},
                new BookCategory { BookId=9, CategoryId=8},
                new BookCategory { BookId=9, CategoryId=12},

                new BookCategory { BookId=10, CategoryId=5},
                new BookCategory { BookId=10, CategoryId=1},
                new BookCategory { BookId=10, CategoryId=10},

                new BookCategory { BookId = 11, CategoryId = 5 },
                new BookCategory { BookId = 11, CategoryId = 1 },
                new BookCategory { BookId = 11, CategoryId = 10 },

                new BookCategory { BookId=12, CategoryId=2},
                new BookCategory { BookId=12, CategoryId=9},
                new BookCategory { BookId=12, CategoryId=6},

                new BookCategory { BookId=13, CategoryId=5},
                new BookCategory { BookId=13, CategoryId=10},
                new BookCategory { BookId=13, CategoryId=11},

                new BookCategory { BookId = 14, CategoryId = 5 },
                new BookCategory { BookId = 14, CategoryId = 1 },
                new BookCategory { BookId = 14, CategoryId = 10 },

                new BookCategory { BookId=15, CategoryId=13},
                new BookCategory { BookId=15, CategoryId=14},

                new BookCategory { BookId=16, CategoryId=13},
                new BookCategory { BookId=16, CategoryId=4},

                new BookCategory { BookId=17, CategoryId=5},
                new BookCategory { BookId=17, CategoryId=10},

                new BookCategory { BookId=18, CategoryId=5},
                new BookCategory { BookId=18, CategoryId=10},

                new BookCategory { BookId=19, CategoryId=5},
                new BookCategory { BookId=19, CategoryId=1},
                new BookCategory { BookId=19, CategoryId=10},

                new BookCategory { BookId=20, CategoryId=1},
                new BookCategory { BookId=20, CategoryId=3},
                new BookCategory { BookId=20, CategoryId=5});
        }
    }
}
