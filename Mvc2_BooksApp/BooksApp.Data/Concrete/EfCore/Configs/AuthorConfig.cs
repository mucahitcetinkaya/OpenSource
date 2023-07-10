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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.About).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.PhotoUrl).IsRequired();

            builder.HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Genel",
                    LastName = "Yazar",
                    BirthOfYear = 9999,
                    PhotoUrl = "default-profile.jpg",
                    Url = "genel-yazar",
                    IsAlive = false,
                    About = "Bu yazar, yazarı silinmiş kitaplar için kullanılmaktadır."
                },
                new Author
                {
                    Id = 16,
                    FirstName = "İlber",
                    LastName = "Ortaylı",
                    BirthOfYear = 1947,
                    PhotoUrl = "ilber-ortayli.jpg",
                    Url = "ilber-ortayli-1",
                    IsAlive = true,
                    About = "İlber Ortaylı, Türk tarihçi, akademisyen ve yazar. Türk Tarih Kurumu Şeref Üyesidir. Ortaylı, Uluslararası Osmanlı Etütleri Komitesi yönetim kurulu üyesi ve Avrupa İranoloji Cemiyeti ve Avusturya-Türk Bilimler Forumu üyesidir."
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Charlotte Parkins",
                    LastName = "Gilman",
                    BirthOfYear = 1860,
                    PhotoUrl = "charlotte-parkins-gilman.jpg",
                    Url = "charlotte-parkins-gilman-2",
                    IsAlive = false,
                    About = "Charlotte Perkins Gilman, ya da Charlotte Perkıns Stetson, önde gelen Amerikalı feminist, sosyolog, romancı, kısa hikâye, şiir ve kurmaca olmayan metinler yazarı ve sosyal reform eğitmeni. Ütopik bir feministti ve alışılmışın dışındaki konsept ve yaşam tarzından dolayı gelecek nesillere örnek teşkil etti."
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Herbert George",
                    LastName = "Wells",
                    BirthOfYear = 1866,
                    PhotoUrl = "herbert-george-wells.jpg",
                    Url = "herbert-george-wells-3",
                    IsAlive = false,
                    About = "Herbert George Wells ya da daha çok tanındığı adla H. G. Wells, Dünyaların Savaşı, Görünmez Adam, Dr. Moreau'nun Adası ve Zaman Makinesi adlı bilimkurgu romanlarıyla tanınan ama neredeyse edebiyatın her dalında birçok eser vermiş olan İngiliz yazardır. Sosyalist olduğunu açıkça söyleyen H.G. Wells'in çoğu eserinde önemli ölçüde siyasi ve sosyal yorumlar bulunmaktadır. Jules Verne gibi gelecekteki teknolojik gelişmeleri anlattığı kitaplarıyla bilimkurgu dalının öncülerinden hatta yaratıcılarından sayılmaktadır."
                },
                new Author
                {
                    Id = 4,
                    FirstName = "Douglas",
                    LastName = "Adams",
                    BirthOfYear = 1982,
                    PhotoUrl = "douglas-adams.jpg",
                    Url = "douglas-adams-4",
                    IsAlive = true,
                    About = "Okula Essex'de gitti. Cambridge'de St. Johns College'e devam ederken Footlights tiyatro kulübünde görev aldı. Pek çok iş denedi. Hastanede hizmetlilik, inşaat işçiliği, kümes temizlikçiliği, bir Arap aile için korumalık yaptı. Daha sonra BBC'de Dr. Who dizisinde yapımcılık ve senaryo editörlüğü yaptı. Dr. Who'nun üç bölümünü yazdı. Monty Pyton grubundan Graham Chapman ile birlikte çalıştı.\r\n\r\nBBC'de yayımlanan The Hitchhiker's Guide to the Galaxy (Otostopçunun Galaksi Rehberi) adlı radyo oyunu ile ünlü oldu. Oyun, kitap olarak da yayımlandı. Bu radyo oyunundan aynı adlı bir bilgisayar oyunu da üretti. Daha sonra Bureaucracy ve Starship Titanic adlı bilgisayar oyunları üzerinde de çalıştı. Starship Titanic sonradan bir kitap olarak da yayımlandı, ancak Adams'ın hem oyun hem de kitap üzerinde çalışacak zamanı olmadığından kitabı Terry Jones yazdı. İleri derecede bir Beatles hayranıydı."
                },
                new Author
                {
                    Id = 5,
                    FirstName = "Ray Douglas",
                    LastName = "Bradbury",
                    BirthOfYear = 1920,
                    PhotoUrl = "ray-douglas-bradbury.jpg",
                    Url = "ray-douglas-bradbury-5",
                    IsAlive = false,
                    About = "Ray Douglas Bradbury korku ve bilimkurgu tarzlarında yazan Amerikalı bir yazardır. En çok bilinen kitapları 1950'de yazdığı kısa hikâyeler kitabı ve bir roman olan The Martian Chronicles ve 1953'te yazdığı başyapıtı olan Fahrenheit 451'dir. Los Angeles'ta 91 yaşında öldü."
                },
                new Author
                {
                    Id = 6,
                    FirstName = "Osamu",
                    LastName = "Dazai",
                    BirthOfYear = 1909,
                    PhotoUrl = "osamu-dazai.jpg",
                    Url = "osamu-dazai-6",
                    IsAlive = false,
                    About = "Japon yazardır. Tsugaru Yarımadası’nın merkezi yakınlarında küçük bir kasaba olan Kanagi’de doğdu. Asıl adı Şuuci Tsuşima'dır. Ailedeki siyasetçi olma geleneğine karşı çıkarak, yazar olmaya karar verdi. Yirmi yaşında Tokyo Üniversitesi Fransız Edebiyatı Bölümü’ne kaydını yaptırdı. Hayatının büyük bölümünde esrarkeş, veremli, asabi, kavgacı ve alkolik biri olarak birkaç kez intihar etmeye kalkıştı. Dazai, 1948’de metresiyle birlikte suya atlayarak intihar etti. Ölümünün üzerinden bunca sene geçmesine rağmen, Japonya’da hâlâ ilgi gören bir yazardır. Eserlerinin çoğunluğunda yalnızlığı ele alır. Yalnızlık ön planda iken insanın arayış içinde olması ve insanın varoluşunu, içe dönüklüğünü yani temelde insanı ele alır."
                },
                new Author
                {
                    Id = 7,
                    FirstName = "George",
                    LastName = "Orwell",
                    BirthOfYear = 1903,
                    PhotoUrl = "george-orwell.jpg",
                    Url = "george-orwell-7",
                    IsAlive = false,
                    About = "Eric Arthur Blair veya daha bilinen takma adıyla George Orwell 20. yüzyıl İngiliz edebiyatının önde gelen kalemleri arasında yer alan İngiliz romancı, gazeteci ve eleştirmen. En çok, dünyaca ünlü Bin Dokuz Yüz Seksen Dört adlı romanı ve bu romanda yarattığı Big Brother kavramı ile tanınır. "
                },
                new Author
                {
                    Id = 8,
                    FirstName = "Matt",
                    LastName = "Haig",
                    BirthOfYear = 1982,
                    PhotoUrl = "matt-haig.jpeg",
                    Url = "matt-haig-8",
                    IsAlive = true,
                    About = "Matt Haig bir İngiliz yazar ve gazetecidir. Çocuklar ve yetişkinler için, genellikle spekülatif kurgu türünde hem kurgu hem de kurgu olmayan kitaplar yazmıştır. Haig, çocuklar ve yetişkinler için hem kurgu hem de kurgu olmayan kitapların yazarıdır. Kurgusal olmayan çalışması Reasons to Stay Alive , Sunday Times'ın en çok satanlar listesinde bir numaraydı ve 46 hafta boyunca Birleşik Krallık'ta ilk 10'da yer aldı. En çok satan çocuk romanı 'Noel Baba ve Ben' şu anda filme uyarlanıyor, yapımcılığını StudioCanal ve Blueprint Pictures üstleniyor."
                },
                new Author
                {
                    Id = 9,
                    FirstName = "Stephen William",
                    LastName = "Hawking",
                    BirthOfYear = 1942,
                    PhotoUrl = "stephen-william-hawking.jpg",
                    Url = "stephen-william-hawking-9",
                    IsAlive = false,
                    About = "Stephen William Hawking, İngiliz fizikçi, kozmolog, astronom, teorisyen ve yazar. Stephen Hawking, Einstein'dan bu yana dünyaya gelen en parlak teorik fizikçi olarak kabul edilmektedir. 12 onur derecesi almıştır. 1982'de CBE ile ödüllendirilmiş, bundan başka birçok madalya ve ödül almıştır. "
                },
                new Author
                {
                    Id = 10,
                    FirstName = "Fyodor",
                    LastName = "Dostoyevski",
                    BirthOfYear = 1821,
                    PhotoUrl = "fyodor-dostoyevski.jpg",
                    Url = "fyodor-dostoyevski-10",
                    IsAlive = false,
                    About = "Fyodor Mihayloviç Dostoyevski, Rus roman yazarıdır. Çocukluğunu sarhoş bir baba ve hasta bir anne arasında geçiren Dostoyevski, annesinin ölümünden sonra Petersburg'daki Mühendis Okulu'na girdi. Babasının ölüm haberini de burada aldı. Okulu başarıyla bitirdikten sonra istihkâm bölüğüne girdi."
                },
                new Author
                {
                    Id = 11,
                    FirstName = "Manon Steffan",
                    LastName = "Ros",
                    BirthOfYear = 1983,
                    PhotoUrl = "manon-steffan-ros.jpg",
                    Url = "manon-steffan-ros-11",
                    IsAlive = true,
                    About = "Manon Steffan Ros, Galli bir romancı, oyun yazarı, oyun yazarı, senarist ve müzisyendir. Tamamı Galce olan yirmiden fazla çocuk kitabı ve yetişkinler için üç romanın yazarıdır. Ödüllü romanı Blasu, The Seasoning başlığı altında İngilizce'ye çevrildi."
                },
                new Author
                {
                    Id = 12,
                    FirstName = "Mustafa Kemal",
                    LastName = "Atatürk",
                    BirthOfYear = 1881,
                    PhotoUrl = "mustafa-kemal-ataturk.jpg",
                    Url = "mustafa-kemal-ataturk-12",
                    IsAlive = false,
                    About = "Mustafa Kemal Atatürk, Türk asker ve devlet adamıdır. Türk Kurtuluş Savaşı'nın başkomutanı, Türkiye Cumhuriyeti'nin kurucusu ve ilk cumhurbaşkanıdır.Atatürk; çağdaş, ilerici ve laik bir ulus devlet kurmak için siyasal, ekonomik ve kültürel alanlarda sekülarist ve milliyetçi nitelikte yenilikler gerçekleştirdi. Yabancılara tanınan ekonomik ayrıcalıklar kaldırıldı ve onlara ait üretim araçları ve demir yolları millîleştirildi. Tevhîd-i Tedrîsât Kanunu ile eğitim, Türk hükûmetinin denetimine girdi. Seküler ve bilimsel eğitim esas alındı. Binlerce yeni okul yapıldı. İlköğretim ücretsiz ve zorunlu duruma getirildi. Yabancı okullar devlet denetimine alındı. Köylülerin sırtına yüklenen ağır vergiler azaltıldı. Erkeklerin serpuşlarında ve giysilerinde bazı değişiklikler yapıldı. Takvim, saat ve ölçülerde değişikliklere gidildi. Mecelle kaldırılarak yerine seküler Türk Kanunu Medenisi yürürlüğe konuldu. Kadınların sivil ve siyasal hakları pek çok Batı ülkesinden önce tanındı. Çok eşlilik yasaklandı. Kadınların tanıklığı ve miras hakkı, erkeklerinkiyle eşit duruma getirildi. Benzer olarak, dünyanın çoğu ülkesinden önce olarak Türkiye'de kadınlara ilkin yerel seçimlerde (1930), sonra genel seçimlerde (1934) seçme ve seçilme hakkı tanındı. Ceza ve borçlar hukukunda seküler yasalar yürürlüğe konuldu. Sanayi Teşvik Kanunu kabul edildi. Toprak reformu için çabalandı. Arap harfleri temelli Osmanlı alfabesinin yerine Latin harfleri temelli yeni Türk alfabesi kabul edildi. Halkı okuryazar kılmak için eğitim seferberliği başlatıldı. Üniversite Reformu gerçekleştirildi. Birinci Beş Yıllık Sanayi Planı yürürlüğe konuldu. Sınıf ve durum ayrımı gözeten lakap ve unvanlar kaldırıldı ve soyadları yürürlüğe konuldu. Bağdaşık ve birleşmiş bir ulus yaratılması için Türkleştirme siyaseti yürütüldü."
                },
                new Author
                {
                    Id = 13,
                    FirstName = "Yuval Noah",
                    LastName = "Harari",
                    BirthOfYear = 1976,
                    PhotoUrl = "yuval-noah-harari.jpg",
                    Url = "yuval-noah-harari-13",
                    IsAlive = true,
                    About = "Yuval Noah Harari, İsrailli tarihçi ve yazardır. İsrailli bir kamu entelektüeli, tarihçi ve Kudüs İbrani Üniversitesi Tarih Bölümü'nde profesör. Popüler bilim en çok satan kitapları Sapiens: İnsanlığın Kısa Tarihi, Homo Deus: Yarının Kısa Tarihi ve 21.Yüzyıl İçin 21 Ders kitabının yazarıdır."
                },
                new Author
                {
                    Id = 14,
                    FirstName = "Lev Nikolayeviç",
                    LastName = "Tolstoy",
                    BirthOfYear = 1828,
                    PhotoUrl = "lev-nikolayevic-tolstoy.jpg",
                    Url = "lev-nikolayevic-tolstoy-14",
                    IsAlive = false,
                    About = "Rus yazar ve asker. Dünya tarihinin en iyi yazarlarından birisi olarak bilinmektedir. Tolstoy, zengin bir ailenin çocuğu olarak Rusya'nın Tula şehrindeki Yasnaya Polyana adlı bir konakta doğdu. Çok küçük yaşlarında önce annesini, sonra babasını kaybetti; yakınlarının elinde büyüdü. Çocukluğundan beri gerçekleri incelemeye karşı büyük bir ilgisi vardı. Fransızcasını ilerletmiş, Voltaire'i ve Jean-Jacques Rousseau'yu okumuş, bu iki yazarın kuvvetli etkisinde kalmıştı. Daha sonraları Yasnaya Polyana'ya dönen Tolstoy, yoksul köylülerin arasına katıldı. İlk eseri olan 'Çocukluk'u bu sıralarda yazdı."
                },
                new Author
                {
                    Id = 15,
                    FirstName = "Afşin",
                    LastName = "Kum",
                    BirthOfYear = 1972,
                    PhotoUrl = "afsin-kum.jpg",
                    Url = "afsin-kum-15",
                    IsAlive = true,
                    About = "Afşin Kum Kimdir? Afşin Kum, 1972 İzmir doğumlu. Boğaziçi Üniversitesinde bilgisayar mühendisliği, Bilgi Üniversitesinde sinema-televizyon öğrenimi gördü. 1997'den bu yana çeşitli kurumlarda yazılımcı ve yönetici olarak çalıştı."
                });
        }
    }
}
