import { Component, OnInit } from '@angular/core';
import { LinkRendererComponent } from 'src/app/helper-components/LinkRendererComponent';
import { BuildingModel, BuildingsClient } from 'src/app/api-clients';

@Component({
  selector: 'app-buildings-list',
  templateUrl: './buildings-list.component.html',
  styleUrls: ['./buildings-list.component.css']
})
export class BuildingsListComponent implements OnInit {
  isLoading: boolean = false;
  rowData: BuildingModel[] = [];

  columnDefs = [
    { headerName: 'Edificio ID', field: 'buildingId' },
    {
      headerName: 'Código', field: 'code',
      cellRendererFramework: LinkRendererComponent,
      cellRendererParams: ({ data }) => {
        return ({
          inRouterLink: `./`,
          routeParam: data.buildingId,
          value: data.code
        });
      }
    },
    { headerName: 'Nombre', field: 'name' },
  ];

  constructor(
    private client: BuildingsClient
  ) { }

  ngOnInit() {
    this.isLoading = true;

    this.client.getAll()
      .subscribe(result => {
        this.rowData = result.items;
        this.isLoading = false;
      }, err => {
        console.log(err);
      })
  }

}