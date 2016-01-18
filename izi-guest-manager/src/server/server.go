package server

import (
	"fmt"
	"net/http"
)

type Config struct {
	Server struct {
		Port string `"json: API_PORT"`
		Addr string `"json: API_ADDR"`
	} `"json: server"`
}

func Start(cfg Config) {
	listenAddr := cfg.Server.Addr + ":" + cfg.Server.Port

	fmt.Println("server is listening on", listenAddr)
	http.ListenAndServe(listenAddr, nil)
}
