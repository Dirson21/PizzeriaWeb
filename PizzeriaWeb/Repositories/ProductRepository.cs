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

        public int Create(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Product] (Name, Price) VALUES (@name, @price)";
                command.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = product.Name;
                command.Parameters.Add("@price", SqlDbType.Decimal).Value = product.Price;

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE [Product] WHERE [Id] = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = product.Id;
                command.ExecuteNonQuery();
            }
            
        }

        public List<Product> GetAll()
        {
            var result = new List<Product>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM [Product]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product(Convert.ToInt32(reader["Id"]),
                                                Convert.ToString(reader["Name"]),
                                                Convert.ToDecimal(reader["Price"]))
               );
            }
            return result;
           
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

        public int Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE [Product] SET [Name] = @name, [Price] = @price WHERE [Id] = @id";
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = product.Name;
            sqlCommand.Parameters.Add("@price", SqlDbType.Decimal).Value = product.Price;
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = product.Id;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
