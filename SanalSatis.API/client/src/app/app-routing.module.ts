import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './core/guards/auth.guard';


const routes: Routes = [
  {path: '', component: HomeComponent,  data: {breadcrumb: 'Home'}},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data: {breadcrumb: 'Shop'}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: {breadcrumb: 'Basket'}},
  {
    path: 'checkout', canActivate: [AuthGuard], loadChildren: () => import('./checkout/checkout.module')
  .then(mod => mod.CheckoutModule), data: {breadcrumb: 'Checkout'}
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module')
      .then(mod => mod.OrdersModule), data: { breadcrumb: 'Orders' }
  },
  {
    path: 'account', loadChildren: () => import('./account/account.module')
  .then(mod => mod.AccountModule), data: { breadcrumb: {skip: true} }
  },
  {path: '**', redirectTo: '', pathMatch: 'full'}
  // urli tam girmeyi zorunlu kılar yoksa sayfa gelmez.
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
