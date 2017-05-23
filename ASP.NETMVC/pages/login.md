```html
<div class="row">
	<div class="col-md-4 col-md-offset-4">
		<form asp-action="Login" method="post">
			<h4>登录</h4>
			<div class="form-group">
				<label>用户</label>
				<input type="text" name="username" value="" class="form-control"  placeholder="username"/>
			</div>
			<div class="form-group">
				<label>登录</label>
				<input type="text" name="username" value="" class="form-control"  placeholder="password"/>
			</div>
			<div class="form-group">
				<button type="submit" class="btn btn-sm btn-primary">登录</button>
			</div>
		</form>

	</div>
</div>

```