using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtKayitOtomasyon
{
    public class SqlBaglantisi
    { // Sql veri tabanı bağlantısı için bu sınıf oluşturuldu bu sınıftan oluşturulan nesne ile metodumuz çağrılır ve veritabanına bağlanılır.
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=Emin\\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True;TrustServerCertificate=True");
            baglan.Open();
            return baglan;
        }
    }
}
