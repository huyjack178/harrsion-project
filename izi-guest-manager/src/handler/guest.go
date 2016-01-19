package handler

import (
	"store"
	"net/http"
)

type GuestCtrl struct {
	guestStore *store.GuestStore
}

func NewGuestCtrl(guestStore *store.GuestStore) *GuestCtrl  {
	return &GuestCtrl{
		guestStore: guestStore,
	}
}

func (this *GuestCtrl) List(w http.ResponseWriter, r *http.Request)   {

}

func (this *GuestCtrl) Get(w http.ResponseWriter, r *http.Request)   {

}

func (this *GuestCtrl) Create(w http.ResponseWriter, r *http.Request)   {

}

func (this *GuestCtrl) Update(w http.ResponseWriter, r *http.Request)   {

}

func (this *GuestCtrl) Delete(w http.ResponseWriter, r *http.Request)   {

}