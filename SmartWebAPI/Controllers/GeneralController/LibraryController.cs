using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartRepository.Core.Models;
using SmartRepository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWebAPI.Controllers.GeneralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IRepository<lib_region> regioncontext;
        private readonly IRepository<lib_province> provincecontext;
        private readonly IRepository<lib_city> citycontext;
        private readonly IRepository<lib_barangay> barangaycontext;
        public LibraryController(IRepository<lib_region> _regioncontext, 
            IRepository<lib_province> _provincecontext,IRepository<lib_city> _citycontext,
            IRepository<lib_barangay> _barangaycontext)
        {
            regioncontext = _regioncontext;
            provincecontext = _provincecontext;
            citycontext = _citycontext;
            barangaycontext = _barangaycontext;
        }

        [HttpGet, Route("GetAllRegion")]
        public async Task<ActionResult> GetAllRegion()
        {
            try
            {
                var regions = await regioncontext.GetAll();
                return Ok(regions);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAllRegion: {ex}");
            }
        }

        [HttpGet, Route("GetAllProvinceByRegion/{regionCode}")]
        public ActionResult GetAllProvinceByRegion([FromRoute] string regionCode)
        {
            try
            {
                var provinces = provincecontext.Find(w => w.regionCode == regionCode);
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAllProvinceByRegion: {ex}");
            }
        }

        [HttpGet, Route("GetAllCityByProvince/{provinceCode}")]
        public ActionResult GetAllCityByProvince([FromRoute] string provinceCode)
        {
            try
            {
                var cities = citycontext.Find(w => w.provinceCode == provinceCode);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAllCityByProvince: {ex}");
            }
        }

        [HttpGet, Route("GetAllBrgyByCity/{cityCode}")]
        public ActionResult GetAllBrgyByCity([FromRoute] string cityCode)
        {
            try
            {
                var cities = barangaycontext.Find(w => w.cityCode == cityCode);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest($"GetAllBrgyByCity: {ex}");
            }
        }

        [HttpPost, Route("PostRegion")]
        public ActionResult PostRegion()
        {
            try
            {
                lib_region lr = new lib_region();
                lr.regionCode = "000000000";
                lr.regionName = "Central Office";
                lr.name = "CO";
                lr.islandGroupCode = "Luzon";

                var record = regioncontext.Find(w => w.regionCode == lr.regionCode);
                if (record == null)
                {
                    regioncontext.AddAsync(lr);
                }
                else
                {
                    regioncontext.UpdateAsync(lr);
                }
                regioncontext.Complete();
                regioncontext.DisposeContext();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest($"PostRegion: {ex}");
            }
        }
    }
}
