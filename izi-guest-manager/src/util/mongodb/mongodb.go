package mongodb
import (
	mgo "gopkg.in/mgo.v2"
	"util/logs"
)

var (
	log = logs.New("util/mongo")
)

type ConnectOpt struct {
	Address string
	Port string
	Database string
}

type Instance struct {
	opts ConnectOpt
	session *mgo.Session
}

func NewInstance(opts ConnectOpt) (ins *Instance, err error)  {
	ins = &Instance{
		opts: opts,
	}

	ins.session, err = mgo.Dial(opts.Address)
	if err != nil {
		return nil, err
	}

	return ins, nil
}

func (this *Instance) CreateCollection() error  {
	err := this.session.DB(this.opts.Database)
	if err != nil {
		return err
	}

	return nil
}