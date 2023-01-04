using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGUYENVANA025.Data;
using NGUYENVANA025.Models;
namespace NGUYENVANA025.Controllers
{
    public class CompanyNVA025 : Controller
    {
     private readonly ApplicationDbContext _context;

     public CompanyNVA025 (ApplicationDbContext context)
     {
        _context =context;
     }
     // Action trả về view để hiển thị danh sách sinh viên
     public async Task<IActionResult> Index()
     {
       return View(await _context.Company.ToListAsync());
     }

     //acttion trả về view để thêm mới sinh viên
     public IActionResult Create()
     {
        return View();
     }
     ///
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Company company)
    {
        if(ModelState.IsValid)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(company);
    }
//

 // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
    //get : student/Edit/5 tao phuong thuc action Edit kiem tra xem id co ton tai hay khong
    // neu co thi cha ve view cho phep ng dung edit thong tin cua sinh vien do
    public async Task<IActionResult> Edit(string id)
    {
        if(id== null)
        {
            return NotFound();
        }
        var company = await _context.Company.FindAsync(id);
        if(company==null)
        {
            return NotFound();
        }
        return View(company);
    }
    //

    //Post : Student update
    [HttpPost]
    [ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(string id,[Bind("CompanyID,CompanyName")] Company company)
{
    if(id != company.CompanyID)
    {
        return NotFound();
    }
     if (ModelState.IsValid)
     {
         try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(company.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
     }



    // delete/5 tao phuong thuc delete kiem tra id cua sinh viên có tồn tại hay không,nếu có thì trả về view delete và cho phép người dùng xóa thông tin của sinh viên đó
 public async Task<IActionResult> Delete(string id)
    {
        if(id== null)
        {
            return NotFound();
        }
        var company = await _context.Company.
        FirstOrDefaultAsync(m => m.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
    }

    //TAo phuong thuc xoa sinh vien theo ma sinh vien
     [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'ApplicationDbContex.Student'  is null.");
            }
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

        public IActionResult Upload()
        {
            return View();
        }
    //
     private bool StudentExists(string id)
        {
          return _context.Company.Any(e => e.CompanyID == id);
        }

      
    }
}