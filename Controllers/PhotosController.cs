using droppinmono;
using DropPinMono.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DropPinMono.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PhotosController : ControllerBase
  {
    private DatabaseContext context;
    public PhotosController(DatabaseContext _context)

    {
      this.context = _context;
    }

    // Create a Photo

    [HttpPost]
    public ActionResult<Photos> CreatePhotos([FromBody]Photos entry)
    {
      context.Photo.Add(entry);
      context.SaveChanges();
      return entry;
    }

    // Get all photos

    [HttpGet]
    public ActionResult<IEnumerable<Photos>> GetAllPhotos()
    {
      var gallery = context.Photo.OrderByDescending(p => p.DateCreated);
      return gallery.ToList();
    }

    // Get photos by location

    [HttpGet("{LatLong}")]
    public ActionResult<Photos> GetPhotoLoca(int LatLong)
    {
      var photoLoca = context.Photo.FirstOrDefault(p => p.Id == LatLong);
      if (photoLoca == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(photoLoca);
      }
    }


    // Update Hearts Count

    [HttpPatch("{id}/Hearts")]
    public ActionResult<Photos> updateHeartsCount(int id)
    {
      var photos = context.Photo.FirstOrDefault(p => p.Id == id);
      if (photos == null)
      {
        return NotFound();
      }
      else
      {
        photos.Hearts += 1;
        context.SaveChanges();
        return photos;
      }


    }
  }
}