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


        //////////////////////////////////////////////GETALL//////////////////////////////////////////////
       
        //FUNCIONALIDAD DE ESTE METODO:
        //PRIMERO CREAMOS UNA LISTA DE DIRECCIONES: List<Address> addresses
        //LUEGO USAMOS EL METODO ExecuteReader de la clase SqlHelper PARA EJECUTAR LA CONSULTA ALMACENADA EN SelectAllStatement.
        //EL METODO ExecuteReader DE LA CLASE SqlHelper DEVUELVE UN OBJETO SqlDataReader, QUE PODEMOS USAR PARA ITERAR ATRAVES DE LOS RESULTADOS DE LA CONSULTA.
        //DENTRO DE while LEEMOS LOS VALORES DE CADA FILA Y LOS ASIGNAMOS A UNA NUEVA INSTANCIA DE LA CLASE Address.
        //AGREGAMOS ESA INSTANCIA A LA LISTA DE DIRECCIONES addreses Y DEVOLVEMOS LA LISTA DE DIRECCIONES.


        public IEnumerable<Address> GetAll()
        {
            List<Address> addresses = new List<Address>();

        using (SqlDataReader reader = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text ))
             {
        while (reader.Read())
        {
            Address address = new Address()
            {
                IdAddress = Convert.ToInt32(reader["IdAddress"]),
                Street = reader["Street"].ToString(),
                Number = reader["Number"].ToString(),
                City = reader["City"].ToString()
            };

            addresses.Add(address);
        }
             }

             return addresses;
        }

        /////////////////////////////////////////////GETONE////////////////////////////////////////////////////
        
        public Address GetOne(Guid id)
        {
            //SE DEBE DECLARAR UNA VARIABLE QUE ESTE REFERENCIADO CON LA CLASE ADDRESS.
            //EL CONTENIDO DE ESTA VARIABLE SERA RETORNADA AL FINALIZAR. 
            //SI ESTA VARIABLE SE DECLARA POR DENTRO DEL USING NO SE PODRIA RETORNAR YA QUE SERIA UNA VARIABLE LOCAL.
            
            Address address = default;
            
            //FUNCIONALIDAD DE ESTE METODO:
            //SE UTILIZA UN BLOQUE using PARA CREAR UN OBJETO SqlDataReader LLAMADO db. 
            //EL BLOQUE using ES UNA FORMA DE ASEGURARSE QUE EL OBJETO SqlDataReader SE LIBERE CORRECTAMENTE DESPUES DE QUE SE HAYAN COMPLETADO LAS OPERACIONES NECESARIAS EN LA BASE DE DATOS.
            //AL FINAL DEL BLOQUE using EL OBJETO db SE LIBERARA AUTOMATICAMENTE Y SE CERRARA LA CONEXION DE BASE DE DATOS.
            //EL METODO SQL SqlHelper.ExecuteReader() SE ESTA UTILIZANDO PARA EJECUTAR UNA CONSULTA SQL Y OBTENER RESULTADOS DE UNA BASE DE DATOS. 
            //ENTONCES:
            //SelectOneStatement ES UNA CADENA QUE REPRESENTA LA CONSULTA SQL QUE SE VA A EJECUTAR (DEFINIDOS MAS ARRIBA).
            //System.Data.CommandType.Text ES UN VALOR ENUMERADO QUE INDICA QUE LA CONSULTA SQL ES UN COMANDO DE TEXTO. PUEDE TAMBIEN ESPECIFICARSE SI ES UN STOREPROCEDURE ETC EN LUGAR DE UN TEXTO.
            //new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@IdAddress", id)} ES UN ARREGLO DE PARAMETROS, EN ESTE CASO SOLO SE ESTA PASANDO UN PARAMETRO LLAMADO @IdAddress CON EL VALOR id.

          using (var db = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                  new System.Data.SqlClient.SqlParameter[] 
                    {
                    new System.Data.SqlClient.SqlParameter("@IdAddress", id)
                    })
                )
            
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

        ////////////////////////////////////////////INSERT////////////////////////////////////////////////////

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

        /////////////////////////////////////////////UPDATE///////////////////////////////////////////////

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

        /////////////////////////////////////////////////DELETE///////////////////////////////////////////

        public void Delete(Guid id)
        {

            //Execute NonQuery
            try 
	        {
                SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@IdAddress",id)
                    };

                SqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, parameters);
            }
	        catch (Exception)
	        {

		    throw;
	        }

        }
    }
}
