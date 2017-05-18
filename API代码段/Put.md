### Put 修改 
**模型名称××
```csharp
/// <summary>
/// 更改企业
/// </summary>
/// <remarks>对象内容为json字符串</remarks>
/// <param name="id"></param>
/// <param name="tblCompany"></param>
/// <returns></returns>
[HttpPut("{id}")]
[ProducesResponseType(200,Type= typeof(int))]
public async Task<JsonResult> PutTblCompany([FromRoute] int id, [FromBody] TblCompany tblCompany)
{
    if (!ModelState.IsValid)
    {
        return JsonFailed();
    }

    if (id != tblCompany.Id)
    {
        return JsonFailed("invalid Id");
    }

    _context.Entry(tblCompany).State = EntityState.Modified;

    try
    {
        int re =await _context.SaveChangesAsync();
        return JsonOk(re);
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TblCompanyExists(id))
        {
            return JsonFailed("Not exist");
        }
        else
        {
            throw;
        }
    }
}
```
