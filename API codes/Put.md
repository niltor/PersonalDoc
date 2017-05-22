### Put 修改 
**模型名称××
```csharp
/// <summary>
		/// 供应商审核
		/// </summary>
		/// <param name="id"></param>
		/// <param name="review"></param>
		/// <returns></returns>
				[HttpPut("{id}")]
		public IActionResult PutTblCompany([FromRoute] int id, ReviewSupplierForm review)
		{
			if (!ModelState.IsValid)
			{
				return JsonFailed();
			}

			TblCompany company = _context.TblCompany.SingleOrDefault(m => m.Id == id);

			if (company?.Id != null)
			{
				company.Status = review.Status;
				company.ReviewMsg = review.ReviewMsg;

				int re = _context.SaveChanges();
				return JsonOk(re);
			}
			else
			{
				return JsonFailed("Not exist");
			}

		}
```
