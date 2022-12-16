using DAL.Contracts;
using DAL.Tools;
using DOM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SqlServer
{
    public class AddressRespository : IGenericRepository<Address>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Address] (Street, Number, City) VALUES (@Street, @Number, @City)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Address] SET (Street, Number, City) WHERE IdAddress = @IdAddress";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Address] WHERE IdAddress = @IdAddress";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdAddress, Street, Number, City FROM [dbo].[Address] WHERE IdAddress = @IdAddress";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdAddress, Street, Number, City FROM [dbo].[Address]";
        }
        #endregion



       

        public IEnumerable<Address> GetAll()
        {

            //sing(var db = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@IdAddress", id) }))
            //{

            //    Address address = new Address();

            //    while (db.Read())
            //    {
            //        address = new Address(Guid.Parse(db[0].ToString()),
            //        db[1].ToString(),
            //        Convert.ToInt32(db[2].ToString()),
            //        db[3].ToString());

            //    }

            //    return address;


            //}

            throw new NotImplementedException();
        }

        public Address GetOne(Guid id)
        {
            //Se debe declarar una variable del tipo objeto Address
            //Se realiza por fuera para usarse como global ya que tambien se debe retornar
            //Si se declara por dentro del using no se podria retornar ya que seria una variable local 
            
            Address address = default;

            using (var db = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@IdAddress", id)} ))
            {

               if (db.Read())
                {
                    //En este caso tendremos un solo registro del tipo objeto-array al cual denominamos x
                    //Al mismo se le asigna un objeto-array que obtiene el numero de columnas [0][1][2][3]

                    object[] x= new object[db.FieldCount];
                    db.GetValues(x);

                    //DATA MAPPER - IdAddress, Street, Number, City
                    //Se le asignan los campos: IdAddress, Street, Number, City a la variable del tipo Address (instancia)
                    
                    address = new Address();
                    address.IdAddress = Guid.Parse(x[0].ToString());
                    address.Street = x[1].ToString();
                    address.Number = int.Parse(x[2].ToString());
                    address.City = x[3].ToString();

                                        

                }

                return address;


            }
               
                    
         }

        public void Insert(Address obj)
        {
            //Execute NonQuery
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    
                    new SqlParameter("@Street",obj.Street),
                    new SqlParameter("@Number",obj.Number),
                    new SqlParameter("@City",obj.City)

                };

                SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, parameters);
            }
            catch (Exception)
            {

                throw;
            }

         
        }

        public void Update(Address obj)
        {
            //Execute NonQuery
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
          {
                new SqlParameter("@IdAddres",obj.IdAddress)

          };

                SqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, parameters);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public void Delete(Guid id)
        {

            //Execute NonQuery

            throw new NotImplementedException();
        }
    }
}
