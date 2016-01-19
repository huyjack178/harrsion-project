package model


type Guest struct {
	Common
	FullName string `json:"fullname"`
	Email string `json:"email"`
	Phone string `json:"phone"`
	RegTime string `json:"regtime"`
	Address string `json:"address"`
	HomeTown string `json:"hometown"`
}