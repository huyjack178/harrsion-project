package server

import (
	"net/http"
)

type Config struct {
	Server struct {
		Port string `json:"API_PORT"`
		Addr string `json:"API_ADDR"`
	} `json:"server"`

	Mongo struct{
		Port string `json:"MONGODB_PORT"`
		Addr string `json:"MONGODB_ADDR"`
		DBName string `json:"MONGODB_DBNAME"`
	} `json:"mongodb"`
}

func Start(cfg Config) {
	s := setup(cfg)

	listenAddr := cfg.Server.Addr + ":" + cfg.Server.Port
	log.Println("server is listening on", listenAddr)
	http.ListenAndServe(listenAddr, s.Handler)

}
