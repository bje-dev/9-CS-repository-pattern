using DAL.Contracts;
using DAL.Tools;
using DOM;
using System;
using System.Collections.Generic;
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



        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetOne(Guid id)
        {
            using (var db = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@IdAddress", id)} ))
            {

                Address address = new Address();

                while (db.Read())
                {
                        address = new Address(Guid.Parse(db[0].ToString()),
                        db[1].ToString(),
                        Convert.ToInt32(db[2].ToString()),
                        db[3].ToString());

                }

                return address ;


            }
               
                    
         }

        public void Insert(Address obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
