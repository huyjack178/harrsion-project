package xhttp
import (
	"net/http"
	"encoding/json"
)

func ResponseJson(w http.ResponseWriter, status int, v interface{})  {
	data, err := json.Marshal(v)
	if err != nil {
		panic(err)
	}

	w.WriteHeader(status)
	w.Write(data)
}
