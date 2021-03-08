﻿let dataTable;

$(document).ready(function () {
	loadDataTable();
});

loadDataTable = () => {
	dataTable = $('#DT_load').DataTable({
		ajax: {
			url: '/api/book',
			type: 'Get',
			'dataType': 'json',
		},
		"columns": [
			{ "data": "name", "width": "30%" },
			{ "data": "author", "width": "30%" },
			{ "data": "isbn", "width": "30%" },
			{
				"data": "id",
				"render": function (data) {
					return `
						<div class='text-center'>
							<a
								href='/BookList/Edit?id=${data}'
								class='btn btn-success text-white' style="cursor: pointer; width: 100px;">Edit</a>
								&nbsp;
								<a
								class='btn btn-danger text-white' style="cursor: pointer; width: 100px;">Delete</a>
						</div>
					`;
				},
				"width": "30%",
			},
		],
		"language": {
			"emptyTable": "No data Found",
		},
		"width": "100%",
	});
};
