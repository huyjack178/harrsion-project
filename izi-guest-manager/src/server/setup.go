package server

import (
	"util/logs"
	"github.com/julienschmidt/httprouter"
	"net/http"
	"util/xhttp"
	"github.com/gorilla/context"
	"store"
	"handler"
	"util/mongodb"
)

var log = logs.New("server")

type setupStruct struct {
	Config

	Mongo *mongodb.Instance
	Handler http.Handler
}

func setup(cfg Config) *setupStruct  {
	s := &setupStruct{Config: cfg}
	s.setupRoutes()
	s.setupMongo()
	return  s
}

func (s *setupStruct) setupMongo()  {
	cfg := s.Config

	mgo, err := mongodb.NewInstance(mongodb.ConnectOpt{
		Address: cfg.Mongo.Addr,
		Database: cfg.Mongo.DBName,
	})

	if err != nil {
		log.Println("Cannot connect DB: error ", err)
	}

	s.Mongo = mgo

	mgo.CreateCollection()
}

func (s *setupStruct) setupRoutes()  {

	normal := func(h http.HandlerFunc) httprouter.Handle {
		return xhttp.Adapt(h)
	}

	router := httprouter.New()

	guestStore := store.NewGuestStore()

	{
		guestCtrl := handler.NewGuestCtrl(guestStore)
		router.GET("/guests", normal(guestCtrl.List))
	}

	s.Handler = context.ClearHandler(router)
}

