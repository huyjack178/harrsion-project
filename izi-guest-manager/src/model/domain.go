package model
import "time"

type TimeStamp struct {
	CreatedTime time.Time `json:"created_time,omitempty"`
	UpdateTime time.Time `"json:"update_time,omitempty"`
}

type Deleted struct  {
	IsDeleted bool `json:"deleted"`
}

type Common struct {
	TimeStamp
	Deleted
	Id string `json:"id,omitempty"`
}