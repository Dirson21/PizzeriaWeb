using SQLHomeWork.Domain;
using System.Data;
using System.Data.SqlClient;

namespace SQLHomeWork.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"\"{nameof(connectionString)}\" не может быть неопределенным или пустым.", nameof(connectionString));
            }

            _connectionString = connectionString;

        }

        public void Delete(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "SELECT [Id], [Name], [Price] FROM [Product] WHERE [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Product(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToDecimal(reader["Price"])
                    );
            }
            else
            {
                return null;
            }
        }

        public Product GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "SELECT [Id], [Name], [Price] FROM [Product] WHERE [Name] = @name";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = name;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Product(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]), 
                    Convert.ToDecimal(reader["Price"])
                    );
            }
            else
            {
                return null;
            }

        }

        public void Update(Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
