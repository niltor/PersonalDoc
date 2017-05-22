```csharp
[HttpGet]
[ProducesResponseType(typeof(User), 200)]
public JsonResult GetUser(Guid id)
{
    User re = _context.Users.Find(id);
    if (re == null)
    {
        return JsonFailed("Not exist");
    }

    return JsonOk(re);
}

```