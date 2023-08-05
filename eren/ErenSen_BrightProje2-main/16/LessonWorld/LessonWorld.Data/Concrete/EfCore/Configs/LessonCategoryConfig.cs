using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Configs
{
    public class LessonCategoryConfig : IEntityTypeConfiguration<LessonCategory>
    {
        public void Configure(EntityTypeBuilder<LessonCategory> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CategoryId });
            builder.HasData(new LessonCategory { LessonId = 1, CategoryId = 1 },
                            new LessonCategory { LessonId = 2, CategoryId = 1},
                            new LessonCategory { LessonId = 3, CategoryId = 1},
                            new LessonCategory { LessonId = 4, CategoryId = 1 },
                            new LessonCategory { LessonId = 5, CategoryId = 1 },

                            new LessonCategory { LessonId = 6, CategoryId = 2 },
                            new LessonCategory { LessonId = 7, CategoryId = 2 },
                            new LessonCategory { LessonId = 8, CategoryId = 2 },
                            new LessonCategory { LessonId = 9, CategoryId = 2 },
                            new LessonCategory { LessonId = 10, CategoryId = 2 },

                            new LessonCategory { LessonId = 11, CategoryId = 3 },
                            new LessonCategory { LessonId = 12, CategoryId = 3 },
                            new LessonCategory { LessonId = 13, CategoryId = 3 },
                            new LessonCategory { LessonId = 14, CategoryId = 3 },
                            new LessonCategory { LessonId = 15, CategoryId = 3 },

                            new LessonCategory { LessonId = 16, CategoryId = 4 },
                            new LessonCategory { LessonId = 17, CategoryId = 4 },
                            new LessonCategory { LessonId = 18, CategoryId = 4 },
                            new LessonCategory { LessonId = 19, CategoryId = 4 },
                            new LessonCategory { LessonId = 20, CategoryId = 4 },

                            new LessonCategory { LessonId = 21, CategoryId = 5 },
                            new LessonCategory { LessonId = 22, CategoryId = 5 },
                            new LessonCategory { LessonId = 23, CategoryId = 5 },
                            new LessonCategory { LessonId = 24, CategoryId = 5 },
                            new LessonCategory { LessonId = 25, CategoryId = 5 }
                            );
        }
    }
}
