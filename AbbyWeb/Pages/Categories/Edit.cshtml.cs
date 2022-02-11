using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Category { get; set; }
        private readonly ApplicationDbContext _db;

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","The DisplayOrder cannot exactly match the Name");
            }
            if (!ModelState.IsValid) return Page();
             _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";
            return RedirectToPage("Index");

        }
    }
}
