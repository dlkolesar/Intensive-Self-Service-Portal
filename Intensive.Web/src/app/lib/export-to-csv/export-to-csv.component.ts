import { Component, OnInit, Input } from '@angular/core';
import { MatTableDataSource, MatTable } from '@angular/material';

@Component({
  selector: 'ss-export-to-csv',
  templateUrl: './export-to-csv.component.html',
  styleUrls: ['./export-to-csv.component.css']
})
export class ExportToCSVComponent implements OnInit {

  @Input() filename: string;
  @Input() colNames: string[];

  @Input() ds: MatTable<any>;

  constructor() { }

  ngOnInit() {
  }

  exportCSV() {
    // let data = this.ds.;
    // var csv = this.colNames.join(',');
    // var col = "";

    // data.forEach((record, j) => {
    //     csv += '\n';
    //     for (let i = 0; i < this.colNames.length; i++) {
    //         col = this.colNames[i];
    //             csv += '"' + record[col] +'"';  //double quotes around the column data to capture embedded quotes and commas
    //             if (i < (this.colNames.length - 1)) {
    //                 csv += ',';
    //             }
    //     }
    // });

    // let data = this.ds.; //cdk-table object
    // var csv = this.colNames.join(',');
    // var col = "";

    // data..forEach((record, j) => {
    //     csv += '\n';
    //     for (let i = 0; i < this.colNames.length; i++) {
    //         col = this.colNames[i];
    //             csv += '"' + record[col] +'"';  //double quotes around the column data to capture embedded quotes and commas
    //             if (i < (this.colNames.length - 1)) {
    //                 csv += ',';
    //             }
    //     }
    // });


    // this.DownloadFile(csv, this.filename);
  }


  DownloadFile(text, fn) {
    //console.log(text);
    var blob = new Blob([text], { type: 'text/csv;charset=utf-8;' });
    if (navigator.msSaveBlob) { // IE 10+
        navigator.msSaveBlob(blob, fn);
    }
    else //create a link and click it
    {
        var link = document.createElement("a");
        if (link.download !== undefined) // feature detection
        {
            // Browsers that support HTML5 download attribute
            var url = URL.createObjectURL(blob);
            link.setAttribute("href", url);
            link.setAttribute("download", fn);
            link.style.visibility = 'hidden';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    }
  }

}
