Vagrant.configure("2") do | config |
    config.vm.box = "ubuntu/jammy64"
    config.vm.define "docker" do |docker|
        docker.vm.hostname = "docker.lab"
        #docker.vm.network "private_network", ip: "192.168.99.100"
        docker.vm.network "forwarded_port", guest: 5050, host: 80, auto_correct:true
        docker.vm.provision "shell", path: "docker-setup.sh"
        docker.vm.provider "virtualbox" do |vb|
            vb.customize ["modifyvm", :id, "--memory", "2048"]
            vb.gui = true
        end
    end    
end
