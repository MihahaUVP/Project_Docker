Vagrant.configure('2') do | config |
    config.vm.define 'salary' do |salary|
        salary.vm.box = 'Ubuntu-Vagrant'
        salary.vm.hostname = 'base.lab'
        salary.vm.provider 'virtualbox' do |vb|
            vb.customize ['modifyvm', :id, '--memory', '1024']
        end
        salary.vm.network "forwarded_port", guest: 5050, host: 8080
        salary.vm.provision :docker
        salary.vm.provision :docker_compose, yml: "/vagrant/docker-compose.yml", run: "always"
    end
end