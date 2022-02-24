using Microsoft.AspNetCore.Mvc;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        //connects the database
        private readonly DataContext _context;

        public RealEstateController(DataContext context)
        {
            _context = context;

        }

        //gets all the estates in the database - RealEstates
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RealEstate>>> Get()
        {
            try
            {
                //gets all the estates in the database
                var estatesInDB = await _context.RealEstates.ToListAsync();
                //returns all the estates in the database
                return Ok(estatesInDB);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //gets one estate in RealEstate
        [HttpGet("GetEstateById{id}")]
        public async Task<ActionResult<RealEstate>> Get(int id)
        {
            try
            {
                //assigns that chosen estate to variable using the given "id"
                var estate = await _context.RealEstates.FindAsync(id);
                //checks to see if the estate has been found in the database and responds accordingly
                if (estate == null)
                    return BadRequest("No Estate Found.");

                return Ok(estate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        //adds another estate to the database
        [HttpPost("Create")]
        public async Task<ActionResult<List<RealEstate>>> AddRealEstate(RealEstate estate)
        {
            try
            {
                //validates that their is a corresponding agent assigned
                var estateAgentCheck = await _context.EstateAgents.FindAsync(estate.AgentId);

                if (estateAgentCheck == null)
                    return BadRequest("Not A Valid Agent Assigned.");

                //adds the estate to the database
                _context.RealEstates.Add(estate);
                await _context.SaveChangesAsync();

                //gets all the estates in the database
                var estatesInDB = await _context.RealEstates.ToListAsync();
                return Ok(estatesInDB);

            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //updates the estate - chosen by "id"
        [HttpPut("UpdateEstateById{id}")]
        public async Task<ActionResult<List<RealEstate>>> UpdateRealEstate(RealEstate estateObject, int id)
        {
            try
            {
                //assigns that chosen estate to variable using the given "id"
                var dbEstate = await _context.RealEstates.FindAsync(id);

                //checks to ensure it exists in the database
                if (dbEstate == null)
                    return BadRequest("No Estate Found.");

                //validates that their is a corresponding agent assigned
                var estateAgentCheck = await _context.EstateAgents.FindAsync(estateObject.AgentId);

                if (estateAgentCheck == null)
                    return BadRequest("Not A Valid Agent Assigned.");

                //assigns all the new values
                dbEstate.StreetNumber = estateObject.StreetNumber;
                dbEstate.Street = estateObject.Street;
                dbEstate.City = estateObject.City;
                dbEstate.Price = estateObject.Price;

                //saves it
                await _context.SaveChangesAsync();


                //gets all the updated estates in the database
                var estatesInDB = await _context.RealEstates.ToListAsync();
                return Ok(estatesInDB);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //deletes an estate by "id"
        [HttpDelete("DeleteEstateById{id}")]
        public async Task<ActionResult<List<RealEstate>>> DeleteRealEstate(int id)
        {
            try
            {
                //assigns the chosen estate
                var dbEstate = await _context.RealEstates.FindAsync(id);

                //checks to ensure it exists in the database
                if (dbEstate == null)
                    return BadRequest("No Estate Found.");

                //removes the estate from the database
                _context.RealEstates.Remove(dbEstate);

                //saves the changes to the database
                await _context.SaveChangesAsync();

                //gets all the remaining estates in the database
                var estatesInDB = await _context.RealEstates.ToListAsync();
                return Ok(estatesInDB);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
