[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(Insuree insuree)
{
    if (ModelState.IsValid)
    {
        // Base price
        decimal quote = 50m;

        // Age logic
        var age = DateTime.Now.Year - insuree.DateOfBirth.Year;
        if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--;

        if (age <= 18) quote += 100;
        else if (age >= 19 && age <= 25) quote += 50;
        else quote += 25;

        // Car year logic
        if (insuree.CarYear < 2000) quote += 25;
        if (insuree.CarYear > 2015) quote += 25;

        // Car make & model logic
        if (insuree.CarMake.ToLower() == "porsche")
        {
            quote += 25;
            if (insuree.CarModel.ToLower() == "911 carrera")
            {
                quote += 25;
            }
        }

        // Speeding tickets
        quote += insuree.SpeedingTickets * 10;

        // DUI
        if (insuree.DUI)
        {
            quote *= 1.25m;
        }

        // Coverage type
        if (insuree.CoverageType)
        {
            quote += 50;
        }

        // Assign the quote
        insuree.Quote = quote;

        db.Insurees.Add(insuree);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(insuree);
    
< !--
<div class="form-group">
    @Html.LabelFor(model => model.Quote, htmlAttributes: new { @class = "control-label col-md-2" })
    <div class="col-md-10">
        @Html.EditorFor(model => model.Quote, new { htmlAttributes = new { @class = "form-control" } })
        @Html.ValidationMessageFor(model => model.Quote, "", new { @class = "text-danger" })
    </ div >
</ div >
-->
<table class="table">
    <tr>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Email</th>
        <th>Quote</th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>@item.FirstName</td>
        <td>@item.LastName</td>
        <td>@item.EmailAddress</td>
        <td>@String.Format("{0:C}", item.Quote)</td>
    </tr>
</table>