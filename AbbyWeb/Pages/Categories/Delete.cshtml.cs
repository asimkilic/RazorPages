using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public DeleteModel(ApplicationDbContext db)
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

            var category = _db.Categories.Find(Category.Id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
