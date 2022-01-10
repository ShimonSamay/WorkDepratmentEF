using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkDepratmentMisson.Models;

namespace WorkDepratmentMisson.Controllers.api
{
    public class ManagerController : ApiController
    {
        DeprtmentDB DepartmentDB = new DeprtmentDB();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DepartmentDB.Managers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        
        public async Task <IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await DepartmentDB.Managers.FindAsync(id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

      
        public async Task<IHttpActionResult>  Post([FromBody] Manager value)
        {
            try
            {
                DepartmentDB.Managers.Add(value);
                await DepartmentDB.SaveChangesAsync();
                return Ok(DepartmentDB.Managers.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public async Task<IHttpActionResult>  Put(int id, [FromBody]Manager value)
        {
            try
            {
                Manager Somemanager = await DepartmentDB.Managers.FindAsync(id);
                Somemanager.Id = value.Id;
                Somemanager.FirstName = value.FirstName;
                Somemanager.LastName = value.LastName;  
                Somemanager.WorkerAmount = value.WorkerAmount;
                await DepartmentDB.SaveChangesAsync();
                return Ok(DepartmentDB.Managers.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        public async Task <IHttpActionResult> Delete(int id)
        {
            DepartmentDB.Managers.Remove(await DepartmentDB.Managers.FindAsync(id));
            await DepartmentDB.SaveChangesAsync(); 
            return Ok(DepartmentDB.Managers.ToList());
        }

    }
}
