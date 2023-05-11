import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule, NgbPagination } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } 
from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule  } 
from '@angular/forms';
import { NevberComponent } from './nevber/nevber.component';
import { AppRoutingModule } from './app-routing.module';
import { ShoppingModule } from './shopping/shopping.module';
import { RouterModule } from '@angular/router';
import { OrderManageModule } from './order-manage/order-manage.module';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RequestsModule } from './requests/requests.module';
import { AuthInterceptor } from './service/auth.interceptor';
import { CommonModule } from '@angular/common';
import { ServiceModule } from './service/service.module';
@NgModule({
  declarations: [
    AppComponent,
    NevberComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    ShoppingModule,
    RouterModule,
    OrderManageModule,
    RequestsModule,
    NgbPagination,
    ServiceModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],  bootstrap: [AppComponent]
})
export class AppModule { }
