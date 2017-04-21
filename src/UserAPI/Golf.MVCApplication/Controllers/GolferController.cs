using AutoMapper;
using Golf.Global.Implementations;
using Golf.RESTService.Client.Interfaces;
using Golf.ServiceLayer.Dto.Implementations;
using Golf.ViewModels.Golfers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Golf.MVCApplication.Controllers
{
    public class GolferController : Controller
    {
        private readonly ICreateEntity<GolferDto> _createEntity;
        private readonly IRetrieveEntity<GolferDto> _retrieveEntity;
        private readonly IUpdateEntity<GolferDto> _updateEntity;
        private readonly IDeleteEntity _deleteEntity;

        public GolferController(
            ICreateEntity<GolferDto> createEntity,
            IRetrieveEntity<GolferDto> retrieveEntity,
            IUpdateEntity<GolferDto> updateEntity,
            IDeleteEntity deleteEntity
        )
        {
            if (createEntity == null)
            {
                throw new ArgumentNullException(nameof(createEntity));
            }
            if (retrieveEntity == null)
            {
                throw new ArgumentNullException(nameof(retrieveEntity));
            }
            if (updateEntity == null)
            {
                throw new ArgumentNullException(nameof(updateEntity));
            }
            if (deleteEntity == null)
            {
                throw new ArgumentNullException(nameof(deleteEntity));
            }

            _createEntity = createEntity;
            _retrieveEntity = retrieveEntity;
            _updateEntity = updateEntity;
            _deleteEntity = deleteEntity;
        }

        // GET: Golfer
        public async Task<ViewResult> Index(GolferSearchViewModel viewModel, string sortOrder)
        {
            viewModel.FirstNameSortOrder = sortOrder == "firstName" ? "firstNameDesc" : "firstName";
            viewModel.LastNameSortOrder = sortOrder == "lastName" ? "lastNameDesc" : "lastName";
            viewModel.BirthdateSortOrder = sortOrder == "birthdate" ? "birthdateDesc" : "birthdate";
            viewModel.ClassSortOrder = sortOrder == "class" ? "classDesc" : "class";

            var golfers = await _retrieveEntity.RetrieveEntitiesAsync();

            if (!String.IsNullOrEmpty(viewModel.SearchString))
            {
                golfers = golfers.Where(s =>
                    s.FirstName.Contains(viewModel.SearchString, StringComparison.OrdinalIgnoreCase)
                    || s.LastName.Contains(viewModel.SearchString, StringComparison.OrdinalIgnoreCase)
                    || s.Class.ToString().Equals(viewModel.SearchString, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case "fistName":
                    golfers = golfers.OrderBy(s => s.FirstName);
                    break;
                case "firstNameDesc":
                    golfers = golfers.OrderByDescending(s => s.FirstName);
                    break;
                case "lastName":
                    golfers = golfers.OrderBy(s => s.LastName);
                    break;
                case "lastNameDesc":
                    golfers = golfers.OrderByDescending(s => s.LastName);
                    break;
                case "birthdate":
                    golfers = golfers.OrderBy(s => s.Birthdate);
                    break;
                case "birthdateDesc":
                    golfers = golfers.OrderByDescending(s => s.Birthdate);
                    break;
                case "class":
                    golfers = golfers.OrderBy(s => s.Class);
                    break;
                case "classDesc":
                    golfers = golfers.OrderByDescending(s => s.Class);
                    break;
                default:
                    golfers = golfers.OrderBy(s => s.FirstName);
                    break;
            }

            viewModel.Golfers = Mapper.Map<IEnumerable<GolferViewModel>>(golfers)
                .ToPagedList(viewModel.PageNumber, viewModel.PageSize);

            return View(viewModel);
        }

        // GET: Golfer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Golfer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GolferViewModel golfer)
        {
            var createdDriver = await _createEntity.CreateEntityAsync(Mapper.Map<GolferDto>(golfer));

            return RedirectToAction("Index");
        }

        // GET: Golfer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var golfer = await _retrieveEntity.RetrieveEntityAsync(id);

            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<GolferViewModel>(golfer));
        }

        // GET: Golfer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var golfer = await _retrieveEntity.RetrieveEntityAsync(id);

            if (golfer == null)
            {
                return HttpNotFound();
            }

            var golferToEdit = await _updateEntity.UpdateEntityAsync(id, golfer);

            return View(Mapper.Map<GolferViewModel>(golferToEdit));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GolferViewModel golfer)
        {
            var golferDto = Mapper.Map<GolferDto>(golfer);
            var updatedGolfer = await _updateEntity.UpdateEntityAsync(golfer.Id, golferDto);

            return View("Details", Mapper.Map<GolferViewModel>(updatedGolfer));
        }

        // GET: Golfer/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var golferToDelete = await _retrieveEntity.RetrieveEntityAsync(id);

            if (golferToDelete == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<GolferViewModel>(golferToDelete));
        }

        // POST: Golfer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGolfer(int id)
        {
            await _deleteEntity.DeleteEntityAsync(id);

            return RedirectToAction("Index");
        }
    }
}