import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaComponent } from './Page/consulta/consulta.component';
import { InicioComponent } from './Page/inicio/inicio.component';

const routes: Routes = [{ path: '##', redirectTo: '/' },
{path:'',component:InicioComponent},
{path:'inicio',component:InicioComponent},
{path:'Consulta/:id',component:ConsultaComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
