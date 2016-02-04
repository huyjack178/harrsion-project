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

	MgoDB *mongodb.Instance
	Handler http.Handler
}

func setup(cfg Config) *setupStruct  {
	s := &setupStruct{Config: cfg}
	s.setupMongo()
	s.setupRoutes()
	return  s
}

func (s *setupStruct) setupMongo() {
	cfg := s.Config

	mgoIns, err := mongodb.NewInstance(mongodb.ConnectOpt{
		Address: cfg.Mongo.Addr,
		Database: cfg.Mongo.DBName,
		Collections: cfg.Mongo.Collections,
	})

	if err != nil {
		log.Println("Cannot connect DB: error ", err)
	}

	s.MgoDB = mgoIns
}

func (s *setupStruct) setupRoutes()  {

	normal := func(h http.HandlerFunc) httprouter.Handle {
		return xhttp.Adapt(h)
	}

	router := httprouter.New()

	guestStore := store.NewGuestStore(s.MgoDB)

	{
		guestCtrl := handler.NewGuestCtrl(guestStore)
		router.GET("/guests", normal(guestCtrl.List))
		router.GET("/guest/:id", normal(guestCtrl.Get))
		router.POST("/guests", normal(guestCtrl.Create))
		router.PUT("/guest/:id", normal(guestCtrl.Update))
		router.DELETE("/guest/:id", normal(guestCtrl.Delete))

	}

	s.Handler = context.ClearHandler(router)
}

