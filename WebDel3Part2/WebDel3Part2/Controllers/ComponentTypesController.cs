using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDel3Part2.Data;
using WebDel3Part2.Models;
using WebDel3Part2.ViewModels;

namespace WebDel3Part2.Controllers
{
    public class ComponentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComponentTypes
        public async Task<IActionResult> Index()
        {
            var comTypeVMList = new List<ComTypeViewModel>();
            var comTypeList = await _context.ComponentType.ToListAsync();
            foreach (var comType in comTypeList)
            {
                var categoryIds = await _context.ComponentCategoryTypes
                    .Where(com => com.ComponentTypeId == comType.ComponentTypeId).Select(i => i.CategoryId).ToListAsync();
                var categoryNames = new List<string>();
                foreach (var id in categoryIds)
                {
                    categoryNames.Add(await _context.Category.Where(cat => cat.CategoryId == id).Select(i => i.Name).FirstOrDefaultAsync());
                }

                comTypeVMList.Add(new ComTypeViewModel()
                {
                    ComponentType = comType,
                    ChoosenCategories = categoryNames
                });
            }
            return View(comTypeVMList);
        }

        // GET: ComponentTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentType = await _context.ComponentType
                .FirstOrDefaultAsync(m => m.ComponentTypeId == id);
            if (componentType == null)
            {
                return NotFound();
            }

            var categoryIds = await _context.ComponentCategoryTypes
                .Where(com => com.ComponentTypeId == componentType.ComponentTypeId).Select(i => i.CategoryId).ToListAsync();

            var categoryNames = new List<string>();
            foreach (var categoryId in categoryIds)
            {
                var categoryName = await _context.Category.Where(cat => cat.CategoryId == id).Select(i => i.Name)
                    .FirstOrDefaultAsync();
                if (categoryName != null)
                {
                    categoryNames.Add(categoryName);
                }
            }

            var comTypeVM = new ComTypeViewModel()
            {
                ComponentType = componentType,
                ChoosenCategories = categoryNames
            };

            return View(comTypeVM);
        }

        // GET: ComponentTypes/Create
        public IActionResult Create()
        {
            var comTypeVM = new ComTypeViewModel()
            {
                Categories = _context.Category.ToList().Select(category => new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.CategoryId.ToString()
                }).ToList()
            };
            return View(comTypeVM);
        }

        // POST: ComponentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComTypeViewModel componentTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(componentTypeViewModel);
            }

            if (componentTypeViewModel.ChoosenCategories != null)
            {
                var choosenCategories = _context.Category.Where(x =>
                    componentTypeViewModel.ChoosenCategories.Contains(x.CategoryId.ToString()));
                var componentCategoryTypes = new List<ComponentCategoryType>();
                foreach (var choosenCategory in choosenCategories)
                {
                    componentCategoryTypes.Add(new ComponentCategoryType()
                    {
                        CategoryId = choosenCategory.CategoryId,
                        ComponentType = componentTypeViewModel.ComponentType
                    });
                }

                componentTypeViewModel.ComponentType.ComponentCategoryTypes = componentCategoryTypes;
            }

            _context.Add(componentTypeViewModel.ComponentType);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ComponentTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentType = await _context.ComponentType.SingleOrDefaultAsync(x => x.ComponentTypeId == id);
            if (componentType == null)
            {
                return NotFound();
            }

            var categoryIds = await _context.ComponentCategoryTypes
                .Where(com => com.ComponentTypeId == componentType.ComponentTypeId).Select(i => i.CategoryId).ToListAsync();

            var categoryNames = new List<string>();
            foreach (var categoryId in categoryIds)
            {
                var categoryName = await _context.Category.Where(cat => cat.CategoryId == id).Select(i => i.Name)
                    .FirstOrDefaultAsync();
                if (categoryName != null)
                {
                    categoryNames.Add(categoryName);
                }
            }

            var comTypeVM = new ComTypeViewModel()
            {
                ComponentType = componentType,
                ChoosenCategories = categoryNames,
                Categories = _context.Category.ToList().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList()
            };

            return View(comTypeVM);
        }

        // POST: ComponentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComTypeViewModel componentTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(componentTypeViewModel);
            }
            try
            {
                _context.ComponentCategoryTypes.RemoveRange(_context.ComponentCategoryTypes.Where(x => x.ComponentTypeId == componentTypeViewModel.ComponentType.ComponentTypeId));

                if (componentTypeViewModel.ChoosenCategories != null)
                {
                    var choosenCategories = _context.Category.Where(x =>
                        componentTypeViewModel.ChoosenCategories.Contains(x.CategoryId.ToString()));

                    var componentCategoryTypes = new List<ComponentCategoryType>();
                    foreach (var choosenCategory in choosenCategories)
                    {
                        componentCategoryTypes.Add(new ComponentCategoryType()
                        {
                            CategoryId = choosenCategory.CategoryId,
                            ComponentType = componentTypeViewModel.ComponentType
                        });
                    }
                    componentTypeViewModel.ComponentType.ComponentCategoryTypes = componentCategoryTypes;
                }
                _context.Update(componentTypeViewModel.ComponentType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentTypeExists(componentTypeViewModel.ComponentType.ComponentTypeId))
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

        // GET: ComponentTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentType = await _context.ComponentType
                .FirstOrDefaultAsync(m => m.ComponentTypeId == id);
            if (componentType == null)
            {
                return NotFound();
            }

            var categoryIds = await _context.ComponentCategoryTypes
                .Where(com => com.ComponentTypeId == componentType.ComponentTypeId).Select(i => i.CategoryId).ToListAsync();

            var categoryNames = new List<string>();
            foreach (var categoryId in categoryIds)
            {
                var categoryName = await _context.Category.Where(cat => cat.CategoryId == id).Select(i => i.Name)
                    .FirstOrDefaultAsync();
                if (categoryName != null)
                {
                    categoryNames.Add(categoryName);
                }
            }

            var comTypeVM = new ComTypeViewModel()
            {
                ComponentType = componentType,
                ChoosenCategories = categoryNames
            };

            return View(comTypeVM);
        }

        // POST: ComponentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var componentType = await _context.ComponentType.SingleOrDefaultAsync(x => x.ComponentTypeId == id);
            _context.ComponentType.Remove(componentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentTypeExists(long id)
        {
            return _context.ComponentType.Any(e => e.ComponentTypeId == id);
        }
    }
}
