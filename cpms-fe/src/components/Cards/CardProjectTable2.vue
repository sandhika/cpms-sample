<template>

	<!-- Projects Table Column -->
	<a-card :bordered="false" class="header-solid h-full" :bodyStyle="{padding: 0,}">
		<template #title>
			<a-row type="flex" align="middle">
				<a-col :span="24" :md="12">
					<h5 class="font-semibold m-0">Projects Table</h5>
				</a-col>
				<a-col :span="24" :md="12" style="display: flex; align-items: center; justify-content: flex-end">
					<a-button type="primary" @click="showModal">
						<a-icon type="plus" />
				Create New Project
			</a-button>
				</a-col>
			</a-row>
		</template>
		<a-table :columns="columns" :data-source="data" :pagination="false">

			<template slot="code" slot-scope="text">
				<a>{{ text }}</a>
			</template>

			<a-space slot="members" slot-scope="members" :size="-12" class="avatar-chips">
				<template v-for="member in members">
					<a-avatar :key="member" size="small" :src="member" />
				</template>
			</a-space>

			<template slot="company" slot-scope="company">
				<h6 class="m-0">
					<img :src="company.logo" width="25" style="margin-right: 10px;">
					{{ company.name }}
				</h6>
			</template>

			<template slot="projectStage" slot-scope="projectStage">
				<div class="progress-right">
					<div class="text-right text-sm font-semibold text-muted pr-15">{{ projectStage}}%</div>
					<a-progress class="m-0" :percent="projectStage" :show-info="false" size="small" />
				</div>
			</template>

			<template slot="completion" slot-scope="completion">
				<div class="progress-right">
					<div class="text-right text-sm font-semibold text-muted pr-15">{{ completion.value || completion.value == 0 ? completion.value : completion }}%</div>
					<a-progress class="m-0" :percent="completion.value || completion.value == 0 ? completion.value : completion" :show-info="false" size="small" :status="completion.status ? completion.status : 'normal'" />
				</div>
			</template>

			<template slot="editBtn" slot-scope="row">
				<a-row>
					<a-col :span="12">
						<a-button type="link" :data-id="row.key" @click="showEdit">
					<svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
						<path class="fill-gray-7" d="M13.5858 3.58579C14.3668 2.80474 15.6332 2.80474 16.4142 3.58579C17.1953 4.36683 17.1953 5.63316 16.4142 6.41421L15.6213 7.20711L12.7929 4.37868L13.5858 3.58579Z"/>
						<path class="fill-gray-7" d="M11.3787 5.79289L3 14.1716V17H5.82842L14.2071 8.62132L11.3787 5.79289Z"/>
					</svg>
				</a-button>
					</a-col>
					<a-col :span="12">
						<a-button type="link" :data-id="row.key" @click="showDelete">
					<svg width="16" height="16" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
							<path class="fill-danger" fill-rule="evenodd" clip-rule="evenodd" d="M9 2C8.62123 2 8.27497 2.214 8.10557 2.55279L7.38197 4H4C3.44772 4 3 4.44772 3 5C3 5.55228 3.44772 6 4 6L4 16C4 17.1046 4.89543 18 6 18H14C15.1046 18 16 17.1046 16 16V6C16.5523 6 17 5.55228 17 5C17 4.44772 16.5523 4 16 4H12.618L11.8944 2.55279C11.725 2.214 11.3788 2 11 2H9ZM7 8C7 7.44772 7.44772 7 8 7C8.55228 7 9 7.44772 9 8V14C9 14.5523 8.55228 15 8 15C7.44772 15 7 14.5523 7 14V8ZM12 7C11.4477 7 11 7.44772 11 8V14C11 14.5523 11.4477 15 12 15C12.5523 15 13 14.5523 13 14V8C13 7.44772 12.5523 7 12 7Z" fill="#111827"/>
						</svg>
				</a-button>
					</a-col>
					</a-row>
					
				
				
			</template>

		</a-table>
		
	
		<CreateProject :visible="visibleCreate" @submit="onSubmit" />
		<EditProject :visible="visibleEdit" @submit="onSubmit" />
		
	</a-card>
	
</template> 

<script>
	import CreateProject from "../../views/CreateProject.vue";
	import EditProject from "../../views/EditProject.vue";

	export default ({
		components: {
			CreateProject,
			EditProject
		},
		props: {
			data: {
				type: Array,
				default: () => [],
			},
			columns: {
				type: Array,
				default: () => [],
			},
		},
		data() {
			return {
				// Active button for the "Projects" table's card header radio button group.
				projectHeaderBtns: 'all',
				visibleCreate: false,
				visibleEdit: false,
			}
		},
		methods: {
			showModal() {
				this.visibleCreate = true;
			},
			showEdit(e) {
				this.visibleEdit = true;
			},
			showDelete(e) {
				//this.visibleEdit = true;
			},
			onSubmit(values) {
				this.visibleCreate = false;
			}
		},
	})

</script>